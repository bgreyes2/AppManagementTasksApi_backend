using AppManagementTaskApi.DTOs;

namespace AppManagementTaskApi.Services.Interfaces
{
    public interface ITaskUserService
    {
        Task<List<TaskUserDto>> GetTaskWithUserAsync();
        Task<TaskUserDto?> GetTaskByIdAsync(int id);
        Task<string> UpdateTaskStatusAsync(int id, string status);
        Task<bool> DeleteTaskAsync(int id);
    }
}