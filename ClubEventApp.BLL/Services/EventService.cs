// ClubEventApp.BLL/Services/EventService.cs
using ClubEventApp.BLL.IServices;
using ClubEventApp.DAL.Entities;
using ClubEventApp.DAL.IRepositories;
using ClubEventApp.DTO;

namespace ClubEventApp.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;
        public EventService(IEventRepository eventRepo) => _eventRepo = eventRepo;

        public async Task<(bool Success, string ErrorMessage)> CreateEventAsync(
            CreateEventViewModel model, string creatorId)
        {
            // ✅ Business rule: EndTime phải sau StartTime
            if (model.EndTime <= model.StartTime)
                return (false, "Thời gian kết thúc phải sau thời gian bắt đầu.");

            // ✅ Business rule: Deadline phải trước StartTime
            if (model.RegistrationDeadline >= model.StartTime)
                return (false, "Hạn chót đăng ký phải trước khi sự kiện bắt đầu.");

            var evt = new Event
            {
                EventID = Guid.NewGuid().ToString(),
                EventName = model.EventName,
                Description = model.Description,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Location = model.Location,
                MaxCapacity = model.MaxCapacity,
                AvailableSlots = model.MaxCapacity,   // Ban đầu bằng MaxCapacity
                RegistrationDeadline = model.RegistrationDeadline,
                Status = EventStatus.Published, // Lưu và Công bố ngay
                CreatorID = creatorId
            };

            await _eventRepo.AddAsync(evt);
            await _eventRepo.SaveChangesAsync();
            return (true, null);
        }

        public async Task<List<EventSummaryViewModel>> GetPublishedEventsAsync()
        {
            var events = await _eventRepo.GetPublishedEventsAsync();
            return events.Select(e => new EventSummaryViewModel
            {
                EventID = e.EventID,
                EventName = e.EventName,
                Location = e.Location,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                AvailableSlots = e.AvailableSlots,
                Status = e.Status.ToString()
            }).ToList();
        }

        public async Task<List<EventSummaryViewModel>> GetAllEventsAsync()
        {
            var events = await _eventRepo.GetAllEventsAsync();
            return events.Select(e => new EventSummaryViewModel
            {
                EventID = e.EventID,
                EventName = e.EventName,
                Location = e.Location,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                AvailableSlots = e.AvailableSlots,
                Status = e.Status.ToString()
            }).ToList();
        }
    }
}