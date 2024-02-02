using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using yummer_backend.Models.DTOs;

namespace yummer_backend.Interfaces;

public interface IUser
{
    public Task<IdentityResult> RegisterAsync(UserDto userDto);
    
    public Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>> LoginAsync(string email, string password);
}