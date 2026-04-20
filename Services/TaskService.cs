using AppManagementTaskApi.Net.DTOs;
using AppManagementTaskApi.Net.Models.Entities;
using AppManagementTaskApi.Net.Repositories.Interfaces;
using AppManagementTaskApi.Services.Interfaces;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<List<TaskDto>> GetTaskServiceAsync()
    {
        var tasks = await _taskRepository.GetTaskRepositoryAsync();

        return tasks.Select(t => new TaskDto
        {
            id_task = t.id_task,
            title = t.title,
            status = t.status,
            create_date = t.create_date
        }).ToList();
    }

    // GET BY ID
    public async Task<TaskDto?> GetTaskByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task == null)
            return null;

        return new TaskDto
        {
            id_task = task.id_task,
            title = task.title,
            status = task.status,
            create_date = task.create_date
        };
    }

    public async Task<TaskDto> CreateTaskAsync(TaskDto dto)
    {
        var task = new TaskEntities
        {
            title = dto.title,
            description = dto.description,
            status = dto.status,
            create_date = dto.create_date,
            users_id = dto.users_Id
        };

        var created = await _taskRepository.CreateTaskAsync(task);

        return new TaskDto
        {
            id_task = created.id_task,
            title = created.title,
            status = created.status,
            create_date = created.create_date
        };
    }


    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task == null)
            return false;

        await _taskRepository.DeleteAsync(task);

        return true;
    }
}