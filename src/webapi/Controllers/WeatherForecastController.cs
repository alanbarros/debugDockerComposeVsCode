using application.Boundaries.WeatherForecast;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastUseCase useCase;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastUseCase useCase)
        {
            this.useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromServices] WeatherForecastPresenter presenter)
        {
            useCase.Execute();
            return presenter.ViewModel;
        }
    }
}
