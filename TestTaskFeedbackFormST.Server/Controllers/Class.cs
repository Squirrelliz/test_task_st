﻿using Microsoft.AspNetCore.Mvc;

namespace TestTaskFeedbackFormST.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRequestsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserRequestsController> _logger;

        public UserRequestsController(ILogger<UserRequestsController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Post()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}