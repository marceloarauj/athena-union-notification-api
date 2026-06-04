using Notification.Application.Dtos.Output;

namespace Notification.Application.Interfaces
{
    public interface INotificationPublisher
    {
        Task PublishAsync(Guid recipientId, SendNotificationResponseDto notification, CancellationToken cancellationToken = default);
    }
}
