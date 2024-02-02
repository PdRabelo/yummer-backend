using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yummer_backend.Models;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] string model)
    {
        // Seu código de registro aqui, usando ApplicationUser em vez de IdentityUser
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] string model)
    {
        return Ok();
        // Seu código de login aqui, usando ApplicationUser em vez de IdentityUser
    }

    // Adicione outros endpoints conforme necessário
}