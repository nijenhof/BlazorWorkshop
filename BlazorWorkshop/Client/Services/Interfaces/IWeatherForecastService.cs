using BlazorWorkshop.Shared;

namespace BlazorWorkshop.Client.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        public Task<IEnumerable<WeatherForecast>> GetAll();
        public Task<PaginatedResponse<WeatherForecast>> GetPaginated(int page, int pageSize);
        public Task AddForecast(WeatherForecast newForecast);
    }
}
