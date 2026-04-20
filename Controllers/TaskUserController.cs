using AppManagementTaskApi.DTOs;
using AppManagementTaskApi.Net.DTOs;
using AppManagementTaskApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AppManagementTaskApi.Controllers
{
    [ApiController]
    [Route("api/tasksUsers")]
    public class TaskUserController : ControllerBase
    {
        private readonly ITaskUserService _taskUserService;

        public TaskUserController(ITaskUserService taskUserService)
        {
            _taskUserService = taskUserService;
        }

        // GET ALL TASKS (con user incluido)
        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetTaskUser()
        {
            var result = await _taskUserService.GetTaskWithUserAsync();
            return Ok(result);
        }

        //  GET TASK BY ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(int id)
        {
            var result = await _taskUserService.GetTaskByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // CHANGE STATUS
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] string status)
        {
            var result = await _taskUserService.UpdateTaskStatusAsync(id, status);
            return NoContent();
        }

        // DELETE TASK
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskUserService.DeleteTaskAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}