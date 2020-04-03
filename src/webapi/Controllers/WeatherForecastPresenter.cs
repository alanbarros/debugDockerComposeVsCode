using System.Collections.Generic;
using application.Boundaries.WeatherForecast;
using domain;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class WeatherForecastPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Standard(IEnumerable<WeatherForecast> weatherForecasts)
        {
            ViewModel = new OkObjectResult(weatherForecasts);
        }
    }
}