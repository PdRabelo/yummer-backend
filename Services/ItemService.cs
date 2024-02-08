using AutoMapper;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data;
using yummer_backend.Interfaces;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Services;

public class ItemService(ApiDbContext context, IMapper mapper, ILogger<ItemService> logger) : IItemService
{

    public async Task<Item?> CreateItemAsync(ItemDto itemDto)
    {
        logger.LogInformation("Creating item...");
        try
        {
            logger.LogInformation("Mapping item...");
            var item = mapper.Map<Item>(itemDto);
        
            logger.LogInformation($"Mapping completed. Creating item '{item.Name}'...");

            if (context.Items == null)
            {
                logger.LogWarning("Items collection in context is null. Skipping item addition.");
                return null;
            }

            await context.Items.AddAsync(item);
            logger.LogInformation($"Item '{item.Name}' added to context.");

            logger.LogInformation($"Saving changes to the database...");
            await context.SaveChangesAsync();
            logger.LogInformation($"Item '{item.Name}' with Id {item.Id} was created successfully!");
        
            return item;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while creating item: {Message}", ex.Message);
            throw;
        }
    }



    public async Task<Item?> UpdateItemAsync(ItemDto itemDto, Guid id)
    {
        logger.LogInformation($"Updating item with ID {id}...");
        
        if (context.Items == null)
        {
            logger.LogError("Items collection in context is null.");
            return null;
        }

        var item = await context.Items.FirstOrDefaultAsync(i => i.Id == id);

        if (item == null)
        {
            logger.LogInformation($"Item with ID {id} not found.");
            return null;
        }

        mapper.Map(itemDto, item);

        try
        {
            await context.SaveChangesAsync();
            logger.LogInformation($"Item with ID {id} was updated successfully!");
            return item;
        }
        catch (Exception ex)
        {
            logger.LogError($"Error updating item with ID {id}: {ex.Message}");
            throw;
        }
    }
}