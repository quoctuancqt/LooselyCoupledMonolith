using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoseCoupledMonolithic.OrderService
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<OrderContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
