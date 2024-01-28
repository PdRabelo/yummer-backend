using AutoMapper;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Services;

public class UserService(ApiDbContext context, ILogger<UserService> logger, IMapper mapper)
    : IUserService
{
    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            logger.LogInformation("Retrieving all users...");

            var allUsers = await context.Users.ToListAsync();

            logger.LogInformation($"Total user count: {allUsers.Count}");

            return allUsers;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving information from database");
            throw;
        }
    }

    public async Task<User?> GetUserAsync(string id)
    {
        try
        {
            logger.LogInformation("Retrieving user...");

            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id);

            return user;

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving user with ID {id}", id);
            return null;
        }

    }

    public async Task<User?> CreateUserAsync(UserDto newUserDto)
    {
        logger.LogInformation("Checking if user exists...");
        if (await context.Users.AnyAsync(u => u.Email == newUserDto.Email))
        {
            logger.LogInformation("User already exists.");
            return null;
        }
        try
        {
            logger.LogInformation("Creating user...");

            var newUser = mapper.Map<User>(newUserDto);
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            
            logger.LogInformation("User created successfully!");

            return newUser;
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Error creating user");
            throw;
        }
    }

    public async Task<User?> DeleteUserAsync(string id)
    {
        try
        {
            logger.LogInformation("Searching user to delete...");
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                logger.LogInformation("User does not exist!");
                return null;
            }

            logger.LogInformation("Deleting user...");
            await context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
            logger.LogInformation("User delete successfully!");
            return user;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating user!");
            throw;
        }
    }

    public async Task<User?> UpdateUserAsync(string id, UserDto userData)
    {
        try
        {
            logger.LogInformation("Searching user to update...");
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                logger.LogInformation("User does not exist!");
                return null;
            }
            logger.LogInformation($"Found user with id {id}");
            mapper.Map(userData, user);
            await context.SaveChangesAsync();
            logger.LogInformation("User update successfully!");
            return user;

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating user!");
            throw;
        }
    }

}