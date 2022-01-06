using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            Console.WriteLine($"Obiekt {result}");
            return result;
        }

        [HttpGet]
        [Route("currentDay")]
        public IEnumerable<WeatherForecast> Get2()
        {
            var result = _service.Get();
            Console.WriteLine($"Obiekt {result}");
            return result;
        }
        [HttpGet("currentDay2/{max}")]
        public IEnumerable<WeatherForecast> Get3([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get();
            Console.WriteLine($"Obiekt {result}");
            return result;
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody]string name)
        {
            // HttpContext.Response.StatusCode = 401;

            // return StatusCode(401, $"Hello {name}");

            return NotFound($"Hello {name}");
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
        {
            if(count < 1 || request.Min > request.Max)
            {
                return BadRequest();
            }

            var result = _service.Get(count, request);
            return Ok(result);
        }

        
    }
}
