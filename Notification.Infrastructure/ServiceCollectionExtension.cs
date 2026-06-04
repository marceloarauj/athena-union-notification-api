using Mediator.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Handlers;
using Notification.Application.Interfaces;
using Notification.Application.Interfaces.Repositories;
using Notification.Infrastructure.Database;
using Notification.Infrastructure.Hubs;
using Notification.Infrastructure.Publishers;
using Notification.Infrastructure.Repositories;

namespace Notification.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddInfrastructure(IConfiguration configuration)
            {
                services.AddDbContext<AppDbContext>(config =>
                {
                    config.UseNpgsql(configuration.GetConnectionString("postgresql"));
                });

                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<INotificationRepository, NotificationRepository>();
                services.AddScoped<INotificationPublisher, NotificationHubPublisher>();

                return services;
            }

            public IServiceCollection AddMediatorConfig()
            {
                services.AddMediator(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(SendNotificationHandler).Assembly);
                });

                return services;
            }
        }
    }
}
