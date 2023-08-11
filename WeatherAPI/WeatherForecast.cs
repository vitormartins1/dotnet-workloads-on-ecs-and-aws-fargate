namespace WeatherAPI;

public class WeatherForecast
{
    public string? Location { get; set; }

    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }
}