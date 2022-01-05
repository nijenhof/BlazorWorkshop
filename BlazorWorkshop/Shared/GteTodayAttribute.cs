using System.ComponentModel.DataAnnotations;

namespace BlazorWorkshop.Shared
{
    public class GteTodayAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            if (value is not DateTime) return false;

            return (DateTime)value >= DateTime.Now;
        }
    }
}
