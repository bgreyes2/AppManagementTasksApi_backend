using Microsoft.AspNetCore.Mvc;
using AppManagementTaskApi.Net.DTOs;
using AppManagementTaskApi.Services.Interfaces;

namespace AppManagementTaskApi.Net.Controllers
{
   
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // 🔹 GET: api/users
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        public async Task<ActionResult<List<UserDto>>> GetUser()
        {
            var result = await _userService.GetUserServiceAsync();
            return Ok(result);
        }

        // 🔹 GET: api/users/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _userService.CreateUserAsync(request);

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = created.id_user },
                created
            );
        }

        // 🔹 PUT: api/users/{id}
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto request)
        {
            var updated = await _userService.UpdateUserAsync(id, request);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // 🔹 DELETE: api/users/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}