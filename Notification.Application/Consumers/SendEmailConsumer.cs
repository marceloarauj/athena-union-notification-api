using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notification.Application.Options;
using Notification.Domain.Events;

namespace Notification.Application.Consumers
{
    public class SendEmailConsumer
    (
        ISender mediator,
        IOptions<RabbitOptions> options,
        ILogger<IConsumer<SendEmailEvent>> logger
    ) : EventConsumer<SendEmailEvent>(mediator, options, logger);
}
