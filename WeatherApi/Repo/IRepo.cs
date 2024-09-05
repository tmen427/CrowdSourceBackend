using Microsoft.VisualBasic;
using WeatherApi.Models;

namespace WeatherApi.Repo
{
    public interface IRepo
    {

        IEnumerable<InformationDTO> GetByName(string name);
        Task<List<InformationDTO>> GetAll();

        Task<Models.Information?> Post(InformationDTO infoDTO);

        Task DeleteByGuid(Guid guid);

        Task<Models.Information> GetBySingleName(string name);



    }
}
