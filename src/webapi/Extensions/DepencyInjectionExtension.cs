using application.Boundaries.WeatherForecast;
using application.UseCases;
using infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using webapi.Controllers;

namespace webapi.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<WeatherForecastPresenter, WeatherForecastPresenter>();            
            services.AddScoped<IOutputPort>(x => x.GetRequiredService<WeatherForecastPresenter>());

            services.AddScoped<IWeatherForecastUseCase, WeatherForecastUseCase>();
            services.AddScoped<IGetWeatherForecast, GetWeatherForecast>();

            return services;
        }
    }
}