namespace WeatherApi.Models
{
    public class InformationDTO
    {
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

        public string? Comments { get; set; }

        public string? DateTime { get; set; }

        public Guid Guid { get; set; }

    }
}
