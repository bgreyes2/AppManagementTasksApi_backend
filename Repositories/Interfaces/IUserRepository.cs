using AppManagementTaskApi.Net.Models.Entities;

namespace AppManagementTaskApi.Net.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserEntities>> GetUserAsync();
        Task<UserEntities?> GetByIdAsync(int id);
        Task<UserEntities> CreateAsync(UserEntities user);
        Task UpdateAsync(UserEntities user);
        Task DeleteAsync(UserEntities user);
    }
}