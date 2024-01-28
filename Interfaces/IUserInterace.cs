using yummer_backend.Models;
using yummer_backend.Models.DTOs;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(string id);
    Task<User?> CreateUserAsync(UserDto newUser);
    Task<User?> DeleteUserAsync(string id);
    Task<User?> UpdateUserAsync(string id, UserDto user);
}