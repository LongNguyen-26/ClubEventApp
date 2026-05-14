// ClubEventApp.DAL/IRepositories/IEventRepository.cs
using ClubEventApp.DAL.Entities;

namespace ClubEventApp.DAL.IRepositories
{
    public interface IEventRepository
    {
        Task AddAsync(Event evt);
        Task SaveChangesAsync();
        Task<List<Event>> GetPublishedEventsAsync();
    }
}