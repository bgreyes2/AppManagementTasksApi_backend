using AppManagementTaskApi.Net.Models.Entities;

namespace AppManagementTaskApi.Net.Repositories.Interfaces
{
    public interface ITaskUserRepository
    {
        Task<List<TaskEntities>> Get_TaskUserWithRepositoryAsync();
        Task<TaskEntities?> GetByIdAsync(int id);
        Task<bool> UpdateTaskStatusAsync(int id,string status);
        Task DeleteAsync(TaskEntities task);
    }
}