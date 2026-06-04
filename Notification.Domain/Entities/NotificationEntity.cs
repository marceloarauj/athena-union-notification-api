using System.ComponentModel.DataAnnotations.Schema;

namespace Notification.Domain.Entities
{
    [Table("notifications", Schema = Schemes.NOTIFICATION)]
    public class NotificationEntity : BaseEntity
    {
        [Column("recipient_id")]
        public Guid RecipientId { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("message")]
        public string Message { get; set; } = string.Empty;

        [Column("is_read")]
        public bool IsRead { get; set; } = false;

        [Column("read_at")]
        public DateTime? ReadAt { get; set; }
    }
}
