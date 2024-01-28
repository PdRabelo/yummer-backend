using Microsoft.AspNetCore.Mvc;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(
        ILogger<UsersController> logger,
        IUserService userService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var allUsers = await userService.GetAllUsersAsync();
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving users");
                return StatusCode(500, "Error retrieving users");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            try
            {
                var user = await userService.GetUserAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error retrieving user with ID {id}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto newUser)
        {
            try
            {
                logger.LogInformation("Checking data integrity...");

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    logger.LogError("Wrong data format!");
                    return BadRequest(errors);
                }

                var createdUser = await userService.CreateUserAsync(newUser);
                return createdUser == null ? Conflict("Email already exists!") : StatusCode(202, createdUser);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating new user!");
                return StatusCode(500, "Error creating new user!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                if (await userService.DeleteUserAsync(id) != null)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while trying to delete the user!");
                return StatusCode(500, "An error occurred while trying to delete the user!");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                var user = await userService.UpdateUserAsync(id, userDto);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while trying to update the user!");
                return StatusCode(500, "An error occurred while trying to update the user!");
            }
        }
    }
}