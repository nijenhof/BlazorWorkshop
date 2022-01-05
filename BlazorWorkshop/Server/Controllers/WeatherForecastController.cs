using BlazorWorkshop.Data.Interfaces;
using BlazorWorkshop.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

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
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
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
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            var forecast = _forecastRepository.Get(id);

            if (forecast == null) return NotFound("No forecast with that Id could be found");

            return Ok(forecast);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(WeatherForecast newForecast)
        {
            if (newForecast == null) return BadRequest("No Forecast provided");
            if (!ModelState.IsValid) return BadRequest(GetValidationProblemDetails(ModelState));

            await _forecastRepository.AddAsync(newForecast);
            return Ok();
        }

        private static ProblemDetails GetValidationProblemDetails(ModelStateDictionary modelState)
        {
            return new ValidationProblemDetails(modelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
        }
    }
}