using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWorkshop.Shared
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        [Required]
        [GteToday(ErrorMessage = "Date must be after or equal to today")]
        public DateTime Date { get; set; }

        [Required]
        [Range(-100, 100)]
        public int TemperatureC { get; set; }

        [Required]
        public string? Summary { get; set; }

        [NotMapped]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}