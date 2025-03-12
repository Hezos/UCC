using BackEnd.Models;
using MongoDB.Driver;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            _users = database.GetCollection<User>("User");
        }

        public async Task<User> CreateAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task DeleteAsync(string userid)
        {
            var filter = Builders<User>.Filter.Eq(_ => _.Id, userid);
            var result = await _users.DeleteOneAsync(filter);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetAsync(string id)
        {
            return await _users.Find<User>(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Event>> GetEvents()
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

        public async Task UpdateAsync(string id, User user)
        {
            var filter = Builders<User>.Filter.Eq(_ => _.Id, id);
            var result = await _users.ReplaceOneAsync(filter, user);

            if (result.MatchedCount == 0)
            {
                throw new InvalidOperationException("User not found.");
            }

        }
    }
}
