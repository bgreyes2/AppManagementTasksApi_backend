using AppManagementTaskApi.DTOs;
using AppManagementTaskApi.Net.DTOs;

namespace AppManagementTaskApi.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetTaskServiceAsync();
        Task<TaskDto?> GetTaskByIdAsync(int id);
        Task<TaskDto> CreateTaskAsync(TaskDto dto);
        Task<bool> DeleteTaskAsync(int id);
    }
}