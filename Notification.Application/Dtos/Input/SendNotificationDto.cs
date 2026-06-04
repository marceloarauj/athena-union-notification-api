namespace Notification.Application.Dtos.Input
{
    public class SendNotificationDto
    {
        public Guid RecipientId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
