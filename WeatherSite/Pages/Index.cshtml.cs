using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;

namespace WeatherSite.Pages;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Location { get; set; } = "Dallas";

    public string Message { get; private set; } = "";
    public IEnumerable<WeatherForecast>? Items { get; private set; }

    private readonly IConfiguration _configuration;
    private static readonly HttpClient _httpClient = new();

    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task OnGet()
    {
        try
        {
            var requestUri = $"{_configuration["AppSettings:WeatherAPI"]}/WeatherForecast?location={Location}";

            Items = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>(requestUri);
            Message = $"{Items?.Count()} forecast records found";
        }
        catch (HttpRequestException ex)
        {
            Message = ex.Message;
        }
    }
}