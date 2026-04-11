using MediatR;

namespace Notification.Domain.Events
{
    public record EventModel : IRequest<Guid>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
