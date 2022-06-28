using Google.Protobuf.WellKnownTypes;

namespace BlazorApp1.Shared;

public partial class WeatherForecast
{
    public DateTime Date
    {
        get => DateTimeStamp.ToDateTime();
        set { DateTimeStamp = Timestamp.FromDateTime(value.ToUniversalTime()); }
    }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

