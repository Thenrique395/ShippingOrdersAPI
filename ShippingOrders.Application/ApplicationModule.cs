﻿using Microsoft.Extensions.DependencyInjection;
using ShippingOrders.Application.Services;
using ShippingOrders.Application.Subscribers;

namespace ShippingOrders.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices()
                .AddSubscribers();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderService, ShippingOrderService>();
            services.AddScoped<IShippingServiceService, ShippingServiceService>();

            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<ShippingOrderCompletedSubscriber>();

            return services;
        }
    }
}
