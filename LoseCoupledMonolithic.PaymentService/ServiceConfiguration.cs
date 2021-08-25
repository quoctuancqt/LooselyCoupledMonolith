using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Contract;

namespace LoseCoupledMonolithic.PaymentService
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddPaymentService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PaymentContext>(options => options.UseNpgsql(connectionString));

            services.AddOrderClient(configuration["ServerUrl"]);

            return services;
        }
    }
}
