using Notification.Application.Interfaces.Repositories;

namespace Notification.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();

        INotificationRepository NotificationRepository { get; }
    }
}
