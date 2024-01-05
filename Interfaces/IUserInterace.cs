using yummer_backend.Models;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(Guid id);
    Task<User> CreateUserAsync(UserDto newUser);
}