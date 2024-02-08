using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Interfaces;

public interface IItemService
{
    public Task<Item?> CreateItemAsync(ItemDto itemDto);

    public Task<Item?> UpdateItemAsync(ItemDto itemDto, Guid id);

}