using LanguageExt;
using LanguageExt.Common;
using Microsoft.VisualBasic;
using WeatherApi.Models;

namespace WeatherApi.Repo
{
    public interface IRepo
    {

        IEnumerable<InformationDTO> SearchFoodTruckName(string FoodTruckName);
        Task<List<InformationDTO>> GetAllFoodTrucks();
        Task<Models.Information?> PostFoodTruck(InformationDTO infoDTO);
        Task DeleteFoodTruck(Guid guid);
    
    }
}
