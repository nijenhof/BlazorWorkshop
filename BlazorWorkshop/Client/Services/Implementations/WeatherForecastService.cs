using BlazorWorkshop.Client.Services.Interfaces;
using BlazorWorkshop.Shared;
using System.Net.Http.Json;

namespace BlazorWorkshop.Client.Services.Implementations
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddForecast(WeatherForecast newForecast)
        {
            await _httpClient.PostAsJsonAsync("WeatherForecast", newForecast);
        }

        public async Task<IEnumerable<WeatherForecast>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");

            if (result == null)
            {
                return Enumerable.Empty<WeatherForecast>();
            }
            return result;
        }
    }
}
