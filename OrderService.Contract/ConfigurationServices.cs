using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace OrderService.Contract
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddOrderClient(this IServiceCollection services, string baseUri)
        {
            services
                .AddRefitClient<IOrderClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUri));

            return services;
        }
    }
}
