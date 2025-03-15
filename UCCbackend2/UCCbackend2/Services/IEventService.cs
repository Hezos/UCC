﻿using UCCbackend2.Models;

namespace UCCbackend2.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllAsync();

        Task<Event> CreateAsync(Event e);

        Task UpdateAsync(string id, Event e);

        Task DeleteAsync(string id);

        Task<Event> GetAsync(string id);

        Task<List<Event>> GetByUserAsync(string userid);
    }
}
