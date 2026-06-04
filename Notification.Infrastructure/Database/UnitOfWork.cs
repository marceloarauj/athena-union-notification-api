using Microsoft.EntityFrameworkCore.Storage;
using Notification.Application.Interfaces;
using Notification.Application.Interfaces.Repositories;

namespace Notification.Infrastructure.Database
{
    public class UnitOfWork
    (
        AppDbContext context,
        INotificationRepository notificationRepository
    ) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private IDbContextTransaction? _transaction;

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
                return;

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

            if (_transaction == null) return;

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null) return;

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public INotificationRepository NotificationRepository { get; } = notificationRepository;
    }
}
