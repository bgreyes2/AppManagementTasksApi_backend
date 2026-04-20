using AppManagementTaskApi.Net.Data;
using AppManagementTaskApi.Net.Models.Entities;
using AppManagementTaskApi.Net.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppManagementTaskApi.Net.Repositories
{
    public class TaskUserRepository : ITaskUserRepository
    {
        private readonly AplicationDBContext _dbContext;

        public TaskUserRepository(AplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET ALL TASKS WITH USER (JOIN)
        public async Task<List<TaskEntities>> Get_TaskUserWithRepositoryAsync()
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .Include(t => t.User)
                .Where(t => t.User != null)
                .OrderByDescending(t => t.create_date)
                .ToListAsync();
        }

        public async Task<TaskEntities?> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.id_task == id);
        }

     
        public async Task<bool> UpdateTaskStatusAsync(int id, string status)
        {
            var task = await _dbContext.Tasks
                .FirstOrDefaultAsync(t => t.id_task == id);

            if (task == null) return false;

            
            task.status = status;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(TaskEntities task)
        {
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
        }
    }
}