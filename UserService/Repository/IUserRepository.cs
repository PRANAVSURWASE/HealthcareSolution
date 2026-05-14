 using UserService.Models;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<List<User>> GetAllUsersAsync();
        Task AddUser (User user);
        Task<User?> GetByIdAsync(int id);
    }
}
