using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using grpcServer;
using GrpcGreeter;

namespace clientConsole
{
    class Program
    {
        static void Main(string[] args)
        {               

            var channel = GrpcChannel.ForAddress("http://localhost:8008");

            // Cria uma nova instancia do serviço como cliente
            // var weatherClient = new WeatherForeacaster.WeatherForeacasterClient(channel);

            // List<WeatherForecast> weathers = new List<WeatherForecast>();

            // using(var call = weatherClient.HowIsTheWeather(new WeatherRequest()))
            // {
            //     while(await call.ResponseStream.MoveNext())
            //     {
            //         weathers.Add(call.ResponseStream.Current);
            //     }
            // }

            var greetClient = new Greeter.GreeterClient(channel);
            var input = new HelloRequest{ Name = "Alan" };

            var reply = greetClient.SayHello(input);

            Console.WriteLine(reply);
        }
    }
}
