using BlazorApp1.Server.Services;
using BlazorApp1.Shared;
using Grpc.Core;

public class WeatherService : WeatherForecasts.WeatherForecastsBase
{
    private readonly IForecastService _forecastService;

    public WeatherService(IForecastService forecastService)
    {
        _forecastService = forecastService;
    }

    public override Task<WeatherReply> GetWeather(WeatherRequest request, ServerCallContext context)
	{
		var reply = new WeatherReply();

        reply.Forecasts.Add(_forecastService.CreateForecasts(100));

		return Task.FromResult(reply);
	}
}