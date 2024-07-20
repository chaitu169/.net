using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;

namespace HttpClinet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private static HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        //created a static method to initialize a httpclient instance so that no new instance needed to be created for each request
        //static WeatherForecastController()
        //{
        //    _httpClient = new HttpClient();
        //}

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory; // httpClientFactory is used because it creates the httpClient instance based on connection pool(connection pool takes care of establishing connections and closing them at certain intervals)   
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] // ProduceResponseType Attribute is used to specify return types associated with various response codes, swagger uses this information to show on swagger API Documentation 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JsonArray))]
        public async Task<IActionResult> Get(string? cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                return BadRequest("City Name Must not be null");
            
            var url = $"http://api.weatherapi.com/v1/current.json?key=6cef9d3c198d4382b6d134831242007&q={cityName}";

            //wrapping httpclient in using block frees up the unused resources
            //using (var httpClient = new HttpClient())
            //{
            //    var response = await httpClient.GetAsync(url);

            //    return await response.Content.ReadAsStringAsync();
            //}

            
            var httpClient = _httpClientFactory.CreateClient(); 
            var response = await httpClient.GetAsync(url);
            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}
