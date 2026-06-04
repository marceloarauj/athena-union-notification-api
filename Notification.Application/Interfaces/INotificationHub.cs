namespace Notification.Application.Interfaces
{
    public interface INotificationHub
    {
        Task ReceiveNotification(object notification);
    }
}
