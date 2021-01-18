using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Test.Application.ViewModels;
using Test.Domain.Models;

namespace Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<WeatherDto> GetAsync(string cityname)
        {
            using (HttpClient client = new HttpClient())
            {
                WeatherDto CityWeather = new WeatherDto();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=" + cityname + "&appid=31222ec700d66616e4e236f92631aae6"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        CityWeather = JsonConvert.DeserializeObject<WeatherDto>(apiResponse);
                    }
                }
                return CityWeather;
            }
        }
    }
}
