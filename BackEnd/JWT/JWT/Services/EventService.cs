using BackEnd.Models;
using MongoDB.Driver;

namespace JWT.Services
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _events;

        public EventService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("UCC");
            _events = database.GetCollection<Event>("Event");
        }

        public async Task<Event> CreateAsync(Event e)
        {
            await _events.InsertOneAsync(e);
            return e;
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Event>.Filter.Eq(_ => _.Id, id);
            var result = await _events.DeleteOneAsync(filter);
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _events.Find(_ => true).ToListAsync();
        }

        public async Task<Event> GetAsync(string id)
        {
            return await _events.Find<Event>(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetByUserAsync(string userid)
        {
            var result = await _events.Find(e => e.UserId == userid).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(string id, Event e)
        {
            var filter = Builders<Event>.Filter.Eq(_ => _.Id, id);
            var result = await _events.ReplaceOneAsync(filter, e);
            if (result.MatchedCount == 0)
            {
                throw new InvalidOperationException("Event didn't found.");
            }
        }
    }
}
