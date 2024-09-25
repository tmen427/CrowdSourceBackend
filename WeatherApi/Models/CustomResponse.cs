namespace WeatherApi.Models
{
    public class CustomResponse
    {

        public string StatusCode { get; set; }  
        public string Data { get; set; }

        private string _message; 
        public string Message { get => _message; 
            
            set => _message = value ?? throw new ArgumentNullException(nameof(value));
        
        
        
        } 
        public bool Sucess { get; set; } 

    }
}
