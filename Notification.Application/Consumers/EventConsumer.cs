using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notification.Application.Options;
using Notification.Domain.Events;

namespace Notification.Application.Consumers
{
    public abstract class EventConsumer<TEvent>
    (
        ISender sender, 
        IOptions<RabbitOptions> options, 
        ILogger<IConsumer<TEvent>> logger
    ) : IConsumer<TEvent> where TEvent : EventModel
    {
        public async Task Consume(ConsumeContext<TEvent> context)
        {
            var @event = context.Message;
            try
            {
                if (logger.IsEnabled(LogLevel.Trace))
                {
                    logger.LogTrace("Event #{EventId} received, retry: #{retryCount}", @event.Id, context.GetRetryCount());
                }
                await sender.Send(@event);

            } catch (Exception ex)
            {
                //validar máximo de tentativas
            }
        }
    }
}
