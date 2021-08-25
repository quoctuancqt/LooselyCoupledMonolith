using LoseCoupledMonolithic.OrderService;
using LoseCoupledMonolithic.PaymentService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;

namespace LoseCoupledMonolithic.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrderService(Configuration);

            services.AddPaymentService(Configuration);

            services.AddOpenTelemetryTracing((builder) => builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("ApiServer"))
                    .AddJaegerExporter(opts =>
                    {
                        opts.AgentHost = Configuration["Jaeger:AgentHost"];
                        opts.AgentPort = Convert.ToInt32(Configuration["Jaeger:AgentPort"]);
                    }));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
