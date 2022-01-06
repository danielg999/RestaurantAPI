using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            /*return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();*/
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                rng.Next(-20, 55),
                Summaries[rng.Next(Summaries.Length)]
            )).ToArray();
        }

        public IEnumerable<WeatherForecast> Get(int count, TemperatureRequest request)
        {
            var rng = new Random();
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                rng.Next(request.Min, request.Max),
                Summaries[rng.Next(Summaries.Length)]
            )).ToArray();
        }
    }
}
