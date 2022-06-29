using BlazorApp1.Shared;

namespace BlazorApp1.Server.Services
{
    public interface IForecastService
    {
        IEnumerable<WeatherForecast> CreateForecasts(int numberOfDays);
    }

    public class ForecastService : IForecastService
	{
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> CreateForecasts(int numberOfDays)
        {
            return Enumerable.Range(1, numberOfDays).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}
