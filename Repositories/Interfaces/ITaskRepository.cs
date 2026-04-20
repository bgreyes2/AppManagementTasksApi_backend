using AppManagementTaskApi.Net.Models.Entities;

namespace AppManagementTaskApi.Net.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskEntities>> GetTaskRepositoryAsync();
        Task<TaskEntities?> GetByIdAsync(int id);
        Task<TaskEntities> CreateTaskAsync(TaskEntities task);
        Task DeleteAsync(TaskEntities task);
    }
}