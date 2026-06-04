using Notification.Domain.Entities;

namespace Notification.Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task AddAsync(NotificationEntity notification);
        Task<NotificationEntity?> FindByIdAsync(Guid id);
        Task<List<NotificationEntity>> GetByRecipientAsync(Guid recipientId);
    }
}
