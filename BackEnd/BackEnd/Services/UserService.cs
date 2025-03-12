using BackEnd.Models;
using MongoDB.Driver;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("UCC");
            _users = database.GetCollection<User>("CelestialBodies");
        }

        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string userid)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public User test()
        {
            User user = new User();
            user.Id = "1";
            user.Name = "test";
            user.Password = "password";
            return user;
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
