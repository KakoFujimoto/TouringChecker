using Microsoft.AspNetCore.Mvc;
using TouringChecker.Dtos;
using TouringChecker.Services;

namespace TouringChecker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        private readonly TouringService _touringService;



        public WeatherController(
            WeatherService weatherService,
            TouringService touringService
            )
        {
            _weatherService = weatherService;
            _touringService = touringService;
        }

        [HttpGet("tomorrow")]
        public async Task<IActionResult> GetTomorrow([FromQuery] string city)
        {
            var result = await _weatherService.GetTomorrowAsync(city);
            return Ok(result);
        }

        [HttpPost("check")]
        public async Task<IActionResult> Check(
            [FromBody] TouringCheckRequest request)
        {
            var result = await _touringService.Check(request);
            return Ok(result);
        }
    }
}