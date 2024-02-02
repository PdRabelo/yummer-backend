using AutoMapper;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using yummer_backend.Interfaces;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Services;

public class UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, ILogger<UserService> logger)
    : IUser
{

    public async Task<IdentityResult> RegisterAsync(UserDto userDto)
    {
        try
        {
            logger.LogInformation("Mapping user...");
            var user = mapper.Map<User>(userDto);
            
            logger.LogInformation("Creating user...");
            var result = await userManager.CreateAsync(user, user.PasswordHash!);

            if (!result.Succeeded)
            {
                logger.LogInformation("Unable to create new user");
                return result;
            }
            
            logger.LogInformation($"User {user.Email} created successfully!");
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError("{Message}", ex.Message);
            throw;
        }
    }

    public async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>> LoginAsync(string email, string password)
    {
        try
        {
            signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            logger.LogInformation("Login in...");
            var result = await signInManager.
                PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded)
            {
                logger.LogInformation("Unable to login!");
                return TypedResults.Empty;
            }
            logger.LogInformation($"User {email} logged in successfully!");
            return TypedResults.Empty;

        }
        catch (Exception ex)
        {
            logger.LogInformation("{Message}", ex.Message);
            throw;
        }
    }
    
}