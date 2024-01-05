using AutoMapper;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data;
using yummer_backend.Models;

public class UserService :IUserService
{
    private readonly ApiDbContext _context;
    private readonly ILogger<UserService> _logger;
    private readonly IMapper _mapper;

    public UserService(ApiDbContext context, ILogger<UserService> logger, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            _logger.LogInformation("Retrieving all users...");

            var allUsers = await _context.Users.ToListAsync();

            _logger.LogInformation($"Total user count: {allUsers.Count}");

            return allUsers;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving information from database");
            throw;
        }
    }

    public async Task<User?> GetUserAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Retrieving user...");

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            return user;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user with ID {id}", id);
            return null;
        }

    }

    public async Task<User> CreateUserAsync(UserDto newUserDto)
    {
        try
        {
            _logger.LogInformation("Creating user...");

            var newUser = _mapper.Map<User>(newUserDto);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("User created sucessfully!");

            return newUser;
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex, "Error creating user");
            throw;
        }
    }

}
