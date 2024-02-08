using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using yummer_backend.Interfaces;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class ItemController(IItemService itemService, ILogger<ItemController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] ItemDto itemDto)
    {
        try
        {
            var createdItem =  await itemService.CreateItemAsync(itemDto);
            return createdItem == null ? BadRequest() : StatusCode(201);
        }
        catch (Exception ex)
        {
            logger.LogError("{Message}", ex.Message);
            throw;
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem([FromBody] ItemDto itemDto, [FromRoute] Guid id)
    {
        try
        {
            var updatedItem = await itemService.UpdateItemAsync(itemDto, id);
            return updatedItem == null ? BadRequest() : StatusCode(204);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while updating item: {Message}", ex.Message);
            return StatusCode(500);
        }
    }

}