using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<NotificationEntity> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
