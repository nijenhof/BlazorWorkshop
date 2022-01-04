using BlazorWorkshop.Data.Interfaces;
using BlazorWorkshop.Shared;

namespace BlazorWorkshop.Data.Repositories
{
    public class WeatherForecastRepository : Repository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(DbContextBase context) : base(context)
        {
        }
    }
}
