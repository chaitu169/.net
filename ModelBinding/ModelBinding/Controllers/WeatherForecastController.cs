using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //once routing system selects the endpoint, the model binding kicks in to start mapping parameters with appropriate values
        [HttpGet("{id}")]
        public string Get([FromQuery]int id, [FromHeader(Name = "User-Agent")] string userAgent)
        {
            return $"id - {id}";
        }

        //in this case model binding maps the request properties to properties of class NewType
        [HttpGet]
        public string GetWeatherV2([FromQuery]NewType newType)
        {
            return $"Name - {newType.Name}, UserAgent - {newType.UserAgent}";
        }


        //Model Binding System uses Input Formatters to parse data in request body 
        [HttpPost("PostWeatherInfo")]
        public string PostData([FromBody] CustomData customData)
        {
            return $"data {customData} posted";
        }
    }
}
 