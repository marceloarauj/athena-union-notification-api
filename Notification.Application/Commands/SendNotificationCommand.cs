using AthenaUnionLibrary.ApiResponse;
using Mediator.Mediator;
using Notification.Application.Dtos.Input;
using Notification.Application.Dtos.Output;

namespace Notification.Application.Commands
{
    public record SendNotificationCommand(SendNotificationDto Dto)
        : IRequestMessage<AthenaApiResponse<SendNotificationResponseDto>>;
}
