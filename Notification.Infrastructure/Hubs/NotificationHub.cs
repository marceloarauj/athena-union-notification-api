using Microsoft.AspNetCore.SignalR;
using Notification.Application.Interfaces;

namespace Notification.Infrastructure.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        public async Task JoinRecipientGroup(string recipientId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, recipientId);
        }

        public async Task LeaveRecipientGroup(string recipientId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, recipientId);
        }
    }
}
