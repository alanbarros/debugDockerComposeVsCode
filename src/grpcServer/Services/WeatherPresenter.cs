using System.Collections.Generic;
using System.Linq;
using application.Boundaries.WeatherForecast;

namespace grpcServer.Services
{
    public class WeatherPresenter : IOutputPort
    {
        public List<WeatherForecast> Weathers { get; private set;} 
        public void Error(string message)
        {
            throw new System.NotImplementedException();
        }

        public void Standard(IEnumerable<domain.WeatherForecast> weatherForecasts)
        {
            Weathers = new List<WeatherForecast>();

            weatherForecasts.ToList().ForEach(a => 
            {
                Weathers.Add(new WeatherForecast
                {
                    Date = a.Date.ToFileTime(),
                    Summary = a.Summary,
                    TemperatureC = a.TemperatureC,
                    TemperatureF = a.TemperatureF
                });
            });
        }
    }
}