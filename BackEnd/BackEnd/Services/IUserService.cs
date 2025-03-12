using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(User user);

        Task DeleteAsync(string userid);

        Task<User> GetAsync(string id);

        User test();
    }
}
