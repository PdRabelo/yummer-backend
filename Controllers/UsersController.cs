using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data;
using yummer_backend.Models;

namespace Yummer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly ApiDbContext _context;

        public UsersController(
            ILogger<UsersController> logger,
            ApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var user = new User()
            {
                Name = "Nome",
                Password = "Senha",
                Email = "Email",
                BirthDate = DateTime.UtcNow
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            var allUsers = await _context.Users.ToListAsync();
            return Ok(allUsers);
        }

    }
}