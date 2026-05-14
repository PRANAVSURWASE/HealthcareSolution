using UserService.DTOs;
using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<string?> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        Task<List<User>> GetAllUsersAsync();
        Task<string?> CreateUserByAdminAsync(RegisterDto dto);

        Task<User?> GetUserByIdAsync(int id);
    }
}