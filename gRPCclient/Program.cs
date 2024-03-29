﻿using BlazorApp1.Shared;
using Grpc.Net.Client;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new WeatherForecasts.WeatherForecastsClient(channel);

var reply = await client.GetWeatherAsync(new WeatherRequest());

foreach (var forecast in reply.Forecasts)
{
    Console.WriteLine($"Date: {forecast.Date}, Summary: {forecast.Summary}, Temp (in Celsius): {forecast.TemperatureC}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
