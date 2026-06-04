using AthenaUnionLibrary.ApiResponse;
using Mediator.Mediator;
using Notification.Application.Commands;
using Notification.Application.Dtos.Output;
using Notification.Application.Interfaces;
using Notification.Domain.Entities;

namespace Notification.Application.Handlers
{
    public class SendNotificationHandler
    (
        IUnitOfWork unitOfWork,
        INotificationPublisher publisher
    ) : IMessageHandler<SendNotificationCommand, AthenaApiResponse<SendNotificationResponseDto>>
    {
        public async Task<AthenaApiResponse<SendNotificationResponseDto>> Handle(
            SendNotificationCommand request,
            CancellationToken cancellationToken)
        {
            var notification = new NotificationEntity
            {
                Id = Guid.NewGuid(),
                RecipientId = request.Dto.RecipientId,
                Title = request.Dto.Title,
                Message = request.Dto.Message
            };

            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.NotificationRepository.AddAsync(notification);
            await unitOfWork.CommitAsync();

            var response = new SendNotificationResponseDto(notification);

            await publisher.PublishAsync(notification.RecipientId, response, cancellationToken);

            return AthenaApiResponse<SendNotificationResponseDto>.Created(response);
        }
    }
}
