using Notification.Domain.Entities;

namespace Notification.Application.Dtos.Output
{
    public class SendNotificationResponseDto(NotificationEntity entity)
    {
        public Guid Id { get; } = entity.Id;
        public Guid RecipientId { get; } = entity.RecipientId;
        public string Title { get; } = entity.Title;
        public string Message { get; } = entity.Message;
        public DateTime CreatedAt { get; } = entity.CreatedAt;
    }
}
