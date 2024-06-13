


using CrowSource.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Data;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WeatherController : Controller
    {

        private readonly InformationContext _informationContext;
        public WeatherController(InformationContext context)
        {
            _informationContext = context;
        }

        
        [HttpPost]
        public  async Task<Models.Information?> ReturnString(InformationDTO infoDTO)
        {
            try
            {               
                var info = InformationMapper.MapToInformationModel(infoDTO);
                info.Guid = Guid.NewGuid();
    

                var add =  await _informationContext.Informations.AddAsync(info);
                await _informationContext.SaveChangesAsync(true);
             
                return info;
                   
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }


        [HttpGet]
        [Route("GetByName")]
        public IEnumerable<InformationDTO> ReturnByName(string name)
        {
            var informationsList = _informationContext.Informations.Where(x => x.Comments == name);
            var convertToDTO = informationsList.Select(i => InformationMapper.MaptoDTO(i)); 
            return convertToDTO;

        }

  
        [HttpDelete]
        [Route("DeleteByGuid")]

        public async Task DeleteByGuid(Guid guid)
        {

            try
            {
                var searchByGuid = _informationContext.Informations.Single(x => x.Guid == guid);
                _informationContext.Remove(searchByGuid);
                await _informationContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
               // await Console.Out.WriteLineAsync(ex.Message);
                throw new Exception(ex.Message);
            }
        }



        [HttpPut]
        [Route("Home/Put")]
        public async Task UpdateCurrent(InformationDTO info)
        {
            //if the values from the frontend match with values from the backend 
            Models.Information? model = await _informationContext.Informations.FirstOrDefaultAsync(c => c.Longitude == info.Longitude && c.Latitude == info.Latitude);

            if (model != null)
            {
                //add the updated comment 
                model.Comments = info.Comments;
                await _informationContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("unable to find longitude and latitude");
            }

        }


        [HttpGet]
        public async Task<List<InformationDTO>> ReturnAll()
        {
            var informationDTOs = _informationContext.Informations.Select(i=> InformationMapper.MaptoDTO(i)).ToList();
            return informationDTOs;
        }
      


    }
}
