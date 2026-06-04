using Microsoft.EntityFrameworkCore;
using Notification.Application.Interfaces.Repositories;
using Notification.Domain.Entities;
using Notification.Infrastructure.Database;

namespace Notification.Infrastructure.Repositories
{
    public class NotificationRepository(AppDbContext dbContext) : INotificationRepository
    {
        public async Task AddAsync(NotificationEntity notification)
        {
            await dbContext.AddAsync(notification);
        }

        public async Task<NotificationEntity?> FindByIdAsync(Guid id)
        {
            return await dbContext.Notifications.Where(n => n.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<NotificationEntity>> GetByRecipientAsync(Guid recipientId)
        {
            return await dbContext.Notifications
                .Where(n => n.RecipientId == recipientId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }
    }
}
