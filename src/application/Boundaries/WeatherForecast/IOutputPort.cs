using System.Collections.Generic;

namespace application.Boundaries.WeatherForecast
{
    public interface IOutputPort
    {
         void Standard(IEnumerable<domain.WeatherForecast> weatherForecasts);
         void Error(string message);
    }
}