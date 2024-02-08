using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yummer_backend.Interfaces;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController(IUserService userServiceService, ILogger<UserController> logger)
    : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]UserDto userDto)
    {
        try
        {
            var result = await userServiceService.RegisterAsync(userDto);
            var errors = !result.Succeeded
                ? result.Errors.Select(identityError => identityError.Description).ToList()
                : null;
            return errors != null ? BadRequest(errors) : Ok();
        }
        catch (Exception ex)
        {
            logger.LogError("{Message}", ex.Message);
            throw;
        }
    }

    [HttpPost("login")]
    public async Task Login(string email, string password)
    {
        try
        {
            await userServiceService.LoginAsync(email, password);
        }
        catch (Exception ex)
        {
            logger.LogError("{Message}", ex.Message);
            throw;
        }
    }
}