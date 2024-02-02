using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace yummer_backend.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class ItemController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        Console.WriteLine("Entrou!");
        return Ok();
    }
}