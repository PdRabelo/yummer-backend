using yummer_backend.Models;
using yummer_backend.Models.DTOs;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(Guid id);
    Task<User?> CreateUserAsync(UserDto newUser);
}