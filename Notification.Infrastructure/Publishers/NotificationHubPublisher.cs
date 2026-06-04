using Microsoft.AspNetCore.SignalR;
using Notification.Application.Dtos.Output;
using Notification.Application.Interfaces;
using Notification.Infrastructure.Hubs;

namespace Notification.Infrastructure.Publishers
{
    public class NotificationHubPublisher(IHubContext<NotificationHub, INotificationHub> hubContext) : INotificationPublisher
    {
        public async Task PublishAsync(Guid recipientId, SendNotificationResponseDto notification, CancellationToken cancellationToken = default)
        {
            await hubContext.Clients
                .Group(recipientId.ToString())
                .ReceiveNotification(notification);
        }
    }
}
