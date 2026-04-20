using AppManagementTaskApi.Net.Data;
using AppManagementTaskApi.Net.Models.Entities;
using AppManagementTaskApi.Net.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AppManagementTaskApi.Net.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDBContext _dbContext;

        public UserRepository(AplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<List<UserEntities>> GetUserAsync()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .OrderBy(u => u.name_user)
                .ToListAsync();
        }

        public async Task<UserEntities?> GetByIdAsync(int id)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.id_user == id);
        }

    
        public async Task<UserEntities> CreateAsync(UserEntities user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(UserEntities user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserEntities user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}