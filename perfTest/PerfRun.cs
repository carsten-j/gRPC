using BenchmarkDotNet.Attributes;
using BlazorApp1.Shared;
using Grpc.Net.Client;
using System.Net.Http.Json;

namespace perfTest
{
    [RPlotExporter]
    public class PerfRun
    {
        private readonly WeatherForecasts.WeatherForecastsClient gRPCClient;
        private readonly HttpClient httpClient;
        private readonly int iterations = 10000;
        private readonly string url = "https://localhost:7069";
        private readonly GrpcChannel channel;

        public PerfRun()
        {
            channel = GrpcChannel.ForAddress(url);
            gRPCClient = new WeatherForecasts.WeatherForecastsClient(channel);

            httpClient = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }


        [Benchmark]
        public async Task gRPCClientPerfRun()
        {
            for (int i = 0; i < iterations; i++)
            {
                var forecasts = (await gRPCClient.GetWeatherAsync(new WeatherRequest())).Forecasts;
            }
        }

        [Benchmark]
        public async Task HttpClientPerfRun()
        {
            for (int i = 0; i < iterations; i++)
            {
                var forecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            }
        }
    }
}
