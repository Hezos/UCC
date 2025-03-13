using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();

        Task<User> CreateAsync(User user);

        Task UpdateAsync(string id, User user);

        Task DeleteAsync(string userid);

        Task<User> GetAsync(string id);

        User test();
    }
}
