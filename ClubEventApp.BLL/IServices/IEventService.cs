// ClubEventApp.BLL/IServices/IEventService.cs
using ClubEventApp.DTO;

namespace ClubEventApp.BLL.IServices
{
    public interface IEventService
    {
        Task<(bool Success, string ErrorMessage)> CreateEventAsync(
            CreateEventViewModel model, string creatorId);
        Task<List<EventSummaryViewModel>> GetPublishedEventsAsync();
        Task<List<EventSummaryViewModel>> GetAllEventsAsync();
    }
}