using Microsoft.AspNetCore.Mvc;
using MockupResponseCMS.API.Models;
using Newtonsoft.Json;

namespace MockupResponseCMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("CMSCortex")]
        public async Task<ActionResult<BaseCommandResponse>> CMSCortexAsigPin([FromBody] CMSCortexAsigPinRequestDto requestDto)
        {
            var response = new BaseCommandResponse();
            try
            {

                if ((requestDto.CardNumber == null || requestDto.CardNumber == "") || (requestDto.ExpirationDate == null || requestDto.ExpirationDate == "") || (requestDto.PinBlock == null || requestDto.PinBlock == "")) 
                {
                    throw new Exception($"Request no valido para procesar");
                }

                CMSCortexAsigPinResponse result = new()
                {
                    ExpDate = "11/27",
                    Pan = "*************3496",
                    RequestDate = "04 / 05 /2021",
                    UserTerminal = "U37750DCG110PP84040613",
                    Timestamp = "2021040508402290",
                    ResponseCode = "0"
                };

                response.Success = true;
                response.Message = "OK";
                response.Parameters = new List<Parameter> { new Parameter { Name = "CMSCortexMarcacionResponse", Value = JsonConvert.SerializeObject(result) } };
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }

        [HttpPost]
        [Route("CMSPrime")]
        public async Task<ActionResult<BaseCommandResponse>> CMSPrimeAsigPin([FromBody] CMSCortexAsigPinRequestDto requestDto)
        {
            var response = new BaseCommandResponse();
            try
            {
                if ((requestDto.CardNumber == null || requestDto.CardNumber == "") || (requestDto.ExpirationDate == null || requestDto.ExpirationDate == "") || (requestDto.PinBlock == null || requestDto.PinBlock == ""))
                {
                    throw new Exception($"Request no valido para procesar");
                }

                CMSCortexAsigPinResponse result = new()
                {
                    ExpDate = "11/27",
                    Pan = "*************3496",
                    RequestDate = "04 / 05 /2021",
                    UserTerminal = "U37750DCG110PP84040613",
                    Timestamp = "2021040508402290",
                    ResponseCode = "0"
                };

                response.Success = true;
                response.Message = "OK";
                response.Parameters = new List<Parameter> { new Parameter { Name = "CMSCortexMarcacionResponse", Value = JsonConvert.SerializeObject(result) } };
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error: {ex.Message}";
                return response;
            }
        }
    }
}
