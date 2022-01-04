using BlazorWorkshop.Data.Interfaces;
using BlazorWorkshop.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWorkshop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _forecastRepository;

        public WeatherForecastController(IWeatherForecastRepository forecastRepository, ILogger<WeatherForecastController> logger)
        {
            _forecastRepository = forecastRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            if (page == 0 || pageSize == 0) return Ok(_forecastRepository.GetAll());


            int totalItems = _forecastRepository.GetAllAsQueryable().Count();
            List<WeatherForecast> forecasts = _forecastRepository
                .GetAllAsQueryable()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new PaginatedResponse<WeatherForecast>(page, pageSize, totalItems, forecasts));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var forecast = _forecastRepository.Get(id);

            if (forecast == null) return NotFound("No forecast with that Id could be found");

            return Ok(forecast);
        }
    }
}