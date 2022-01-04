using BlazorWorkshop.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWorkshop.Data
{
    public class DbContextBase : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbContextBase(DbContextOptions options) : base(options)
        {
        }
    }
}
