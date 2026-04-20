using AppManagementTaskApi.DTOs;
using AppManagementTaskApi.Net.Models.Entities;
using AppManagementTaskApi.Net.Repositories.Interfaces;
using AppManagementTaskApi.Services.Interfaces;

namespace AppManagementTaskApi.Services
{
    public class TaskUserService : ITaskUserService
    {
        private readonly ITaskUserRepository _taskUserRepository;

        public TaskUserService(ITaskUserRepository taskUserRepository)
        {
            _taskUserRepository = taskUserRepository;
        }

        public async Task<List<TaskUserDto>> GetTaskWithUserAsync()
        {
            var tasksUsers = await _taskUserRepository.Get_TaskUserWithRepositoryAsync();

            return tasksUsers.Select(t => new TaskUserDto
            {
                id_task = t.id_task,
                title = t.title,
                description = t.description,
                status = t.status,
                name_user = t.User.name_user,
                email = t.User.email
            }).ToList();
        }

        public async Task<TaskUserDto?> GetTaskByIdAsync(int id)
        {
            var task = await _taskUserRepository.GetByIdAsync(id);

            if (task == null)
                return null;

            return new TaskUserDto
            {
                id_task = task.id_task,
                title = task.title,
                status = task.status,
                name_user = task.User?.name_user,
                email = task.User?.email
            };
        }

        //CHANGE STATUS
        public async Task<string> UpdateTaskStatusAsync(int id, string newStatus)
        {
            var task = await _taskUserRepository.GetByIdAsync(id);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            if (task.status == "Pending" && newStatus == "Done")
                throw new InvalidOperationException("Do not change directly from 'Pending' to 'Done ");


            await _taskUserRepository.UpdateTaskStatusAsync(id, newStatus);

            return "Ok";
        }

        // DELETE TASK
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _taskUserRepository.GetByIdAsync(id);

            if (task == null)
                return false;

            await _taskUserRepository.DeleteAsync(task);

            return true;
        }
    }
}