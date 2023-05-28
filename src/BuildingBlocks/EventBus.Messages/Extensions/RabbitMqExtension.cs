﻿using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventBus.Messages.Extensions
{
    public static class RabbitMqExtension
    {
        public static IServiceCollection AddMasstransitWithRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddMassTransit(x => {
                x.AddConsumers(Assembly.GetEntryAssembly());
                x.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(new Uri(configuration["EventBusSettings:HostAddress"]), host =>
                    {
                        host.Username(configuration["EventBusSettings:Username"]);
                        host.Password(configuration["EventBusSettings:Password"]);
                    });
                    cfg.UseMessageRetry(r => r.Immediate(5));
                    cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter(configuration["ServiceName"], false));
                });
            });


            return services;
        }
    }
}
