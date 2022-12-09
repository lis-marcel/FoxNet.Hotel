using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.ClassConverters
{
    public class ConvertStringToDate
    {
        public static DateOnly? StringToDateOnly(string? stringDate)
        {
            return !string.IsNullOrEmpty(stringDate) ? DateOnly.ParseExact(stringDate, "dd.MM.yyyy") : null;
        }
    }
}
