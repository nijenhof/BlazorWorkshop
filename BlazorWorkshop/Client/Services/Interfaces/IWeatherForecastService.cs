using BlazorWorkshop.Shared;

namespace BlazorWorkshop.Client.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        public Task<IEnumerable<WeatherForecast>> GetAll();
        public Task AddForecast(WeatherForecast newForecast);
    }
}
