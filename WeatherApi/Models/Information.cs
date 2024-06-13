namespace WeatherApi.Models
{
    public class Information
    {
        public int Id { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? DateTime { get; set; }
        public string? Comments { get; set; }    

        public Guid Guid { get; set; } 
    }
}
