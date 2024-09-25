namespace WeatherApi
{
    public class CustomException : Exception
    {

        public int StatusCode { get; set; }
        public string? Message { get; set; }



        public CustomException(string Message) : base(Message) { }  

        
    }
}
