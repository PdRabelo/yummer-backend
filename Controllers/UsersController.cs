using Microsoft.AspNetCore.Mvc;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            ILogger<UsersController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var allUsers = await _userService.GetAllUsersAsync();
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            try
            {
                var user = await _userService.GetUserAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user with ID {id}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto newUser)
        {
            try
            {
                _logger.LogInformation("Checking data integrity...");

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    _logger.LogError("Wrong data format!");
                    return BadRequest(errors);
                }

                var createdUser = await _userService.CreateUserAsync(newUser);
                return createdUser == null ? Conflict("Email already exists!") : StatusCode(202, createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new user!");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}