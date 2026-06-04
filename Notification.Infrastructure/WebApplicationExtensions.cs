using Microsoft.AspNetCore.Builder;
using Notification.Infrastructure.Hubs;

namespace Notification.Infrastructure
{
    public static class WebApplicationExtensions
    {
        extension(WebApplication app)
        {
            public void UseNotificationHubs()
            {
                app.MapHub<NotificationHub>("/hubs/notification");
            }
        }
    }
}
