using System.Reflection;
using FluentValidation;
using MediatR;
using MediatRTest1.Contracts;
using MediatRTest1.LoggingBehaviours;
using MediatRTest1.ValidationBehaviours;
using MediatRTest1.WeatherForecasts;
using MediatRTest1.WeatherForecasts.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MediatRTest1
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
            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IWeatherForecastValidatorService, WeatherForecastValidatorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}