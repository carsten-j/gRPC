using BlazorApp1.Server.Services;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.CreateForecasts(100);
        }
    }
}