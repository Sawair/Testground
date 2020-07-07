using System;
using System.Collections.Generic;
using MediatRDemo.Api.Models;

namespace MediatRDemo.Api.Infrastructure
{
    public class FakeDbContext
    {
        public List<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>()
        {
            new WeatherForecast{ Date = DateTime.Today, Summary = "Not Bad", TemperatureC = 26},
            new WeatherForecast{ Date = DateTime.Today.AddDays(1), Summary = "Not Bad Too", TemperatureC = 22},
        };
    }
}
