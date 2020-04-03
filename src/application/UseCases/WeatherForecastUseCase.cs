using System.Collections.Generic;
using application.Boundaries.WeatherForecast;

namespace application.UseCases
{
    public class WeatherForecastUseCase : IWeatherForecastUseCase
    {
        private readonly IOutputPort output;
        private readonly IGetWeatherForecast getWeather;

        public WeatherForecastUseCase(IOutputPort output, IGetWeatherForecast getWeather)
        {
            this.getWeather = getWeather;
            this.output = output;
        }

        public void Execute()
        {
            IEnumerable<domain.WeatherForecast> weathers;
            
            try
            {
                weathers = getWeather.Get();
                output.Standard(weathers);
            }
            catch (System.Exception e)
            {
                output.Error(e.Message);
            }
        }
    }
}
