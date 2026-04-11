using MassTransit;
using Notification.Application.Consumers;

namespace Notification.Configurations
{
    public static class MassTransitConfigurations
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(options =>
            {
                options.AddConsumer<SendEmailConsumer>();

                options.UsingRabbitMq((context, config) =>
                {
                    //config.Host(new Uri(rabbitConfig.connectstrin));

                    //EndpointConvention.Map<SendEmailEvent>(new Uri("queue:send-email-queue"));

                    config.ReceiveEndpoint("send-email-queue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<SendEmailConsumer>(context);
                    });
                });
            });
        }
    }
}
