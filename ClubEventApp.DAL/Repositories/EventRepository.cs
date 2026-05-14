// ClubEventApp.DAL/Repositories/EventRepository.cs
using ClubEventApp.DAL.Entities;
using ClubEventApp.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClubEventApp.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context) => _context = context;

        public async Task AddAsync(Event evt) => await _context.Events.AddAsync(evt);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public async Task<List<Event>> GetPublishedEventsAsync() =>
            await _context.Events
                .Where(e => e.Status == EventStatus.Published)
                .OrderBy(e => e.StartTime)
                .ToListAsync();
        public async Task<List<Event>> GetAllEventsAsync() =>
            await _context.Events
                .OrderByDescending(e => e.StartTime)
                .ToListAsync();
    }
}