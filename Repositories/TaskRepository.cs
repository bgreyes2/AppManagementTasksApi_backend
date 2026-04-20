using Microsoft.EntityFrameworkCore;
using AppManagementTaskApi.Net.Data;
using AppManagementTaskApi.Net.Models.Entities;
using AppManagementTaskApi.Net.Repositories.Interfaces;

namespace AppManagementTaskApi.Net.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AplicationDBContext _dbContext;

        public TaskRepository(AplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskEntities>> GetTaskRepositoryAsync()
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .OrderByDescending(t => t.create_date)
                .ToListAsync();
        }

      
        public async Task<TaskEntities?> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.id_task == id);
        }

  
        public async Task<TaskEntities> CreateTaskAsync(TaskEntities task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

    
        public async Task DeleteAsync(TaskEntities task)
        {
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
        }
    }
}