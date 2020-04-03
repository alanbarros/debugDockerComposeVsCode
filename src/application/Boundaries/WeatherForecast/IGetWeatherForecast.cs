using System.Collections.Generic;

namespace application.Boundaries.WeatherForecast
{
    public interface IGetWeatherForecast
    {
         IEnumerable<domain.WeatherForecast> Get();
    }
}