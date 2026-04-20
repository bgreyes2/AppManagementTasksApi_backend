using AppManagementTaskApi.Net.DTOs;
using AppManagementTaskApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AppManagementTaskApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

      

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(int id)
        {
            var result = await _taskService.GetTaskByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask([FromBody] TaskDto dto)
        {
            var created = await _taskService.CreateTaskAsync(dto);

            return CreatedAtAction(
                nameof(GetTaskById),
                new { id = created.id_task },
                created
            );
        }

  

        // 🔹 DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}