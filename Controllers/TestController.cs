using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    : ControllerBase
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        return Ok(new { Message = "" });
    }
}