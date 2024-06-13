using WeatherApi.Models;

namespace CrowSource.Conversion
{
    public static class InformationMapper
    {
        public static InformationDTO MaptoDTO(Information information)
        {
          
            return new InformationDTO
            {
                Longitude = information.Longitude,
                Latitude = information.Latitude,
                Comments = information.Comments,
                DateTime = information.DateTime,
                Guid = information.Guid,
            }; 

        }

        public static Information MapToInformationModel(InformationDTO dto) {
            return new Information
            {
                Longitude = dto.Longitude,
                Latitude = dto.Latitude,
                Comments = dto.Comments,
                DateTime = dto.DateTime,
                Guid = dto.Guid,


            }; 
        
        }
    
    }
}
