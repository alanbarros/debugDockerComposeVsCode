using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Boundaries.WeatherForecast;
using Grpc.Core;
using grpcServer.Services;
using Microsoft.Extensions.Logging;

namespace grpcServer
{
    public class WeatherService : WeatherForeacaster.WeatherForeacasterBase
    {
        private readonly IWeatherForecastUseCase useCase;
        private readonly WeatherPresenter presenter;

        public WeatherService(IWeatherForecastUseCase useCase, WeatherPresenter presenter)
        {
            this.presenter = presenter;
            this.useCase = useCase;
        }

        public override async Task HowIsTheWeather(
            WeatherRequest request,
            IServerStreamWriter<WeatherForecast> responseStream,
            ServerCallContext context)
        {
            useCase.Execute();

            foreach (var weather in presenter.Weathers)
            {
                await responseStream.WriteAsync(weather);
            }
        }
    }
}
