﻿using UCCbackend2.Models;

namespace UCCbackend2.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(string id, User user);

        Task DeleteAsync(string userid);

        Task<User> GetAsync(string id);

        User test();
    }
}
