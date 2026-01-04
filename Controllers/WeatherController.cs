using Microsoft.AspNetCore.Mvc;
using TouringChecker.Services;

namespace TouringChecker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("tomorrow")]
        public IActionResult GetTomorrow([FromQuery] string city)
        {
            var result = _weatherService.GetTomorrow(city);
            return Ok(result);
        }
    }
}
