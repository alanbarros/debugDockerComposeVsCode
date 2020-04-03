using application.Boundaries.WeatherForecast;
using application.UseCases;
using grpcServer.Services;
using infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace grpcServer.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<WeatherPresenter, WeatherPresenter>();            
            services.AddScoped<IOutputPort>(x => x.GetRequiredService<WeatherPresenter>());

            services.AddScoped<IWeatherForecastUseCase, WeatherForecastUseCase>();
            services.AddScoped<IGetWeatherForecast, GetWeatherForecast>();

            return services;
        }
    }
}