


using CrowSource.Conversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WeatherApi.Data;
using WeatherApi.Models;
using WeatherApi.Repo;

namespace WeatherApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WeatherController : Controller
    {

      // private readonly InformationContext _informationContext;
        private readonly IRepo _informationConnection;
        public WeatherController(IRepo informationConnection)
        {
        //   _informationContext = context;
            _informationConnection = informationConnection;

        }

        
        [HttpPost]
        public  async Task<Models.Information?> ReturnString(InformationDTO infoDTO)
        {
            try
            {               
               return await _informationConnection.Post(infoDTO);    
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
           return _informationConnection.GetByName(name);

        }

  
        [HttpDelete]
        [Route("DeleteByGuid")]

        public async Task DeleteByGuid(Guid guid)
        {

            try
            {
               await _informationConnection.DeleteByGuid(guid);
            }
            catch(Exception ex)
            {
           
              throw new Exception(ex.Message);
            }
        }



        //[HttpPut]
        //[Route("Home/Put")]
        //public async Task UpdateCurrent(InformationDTO info)
        //{
        //    //if the values from the frontend match with values from the backend 
        //    Models.Information? model = await _informationContext.Informations.FirstOrDefaultAsync(c => c.Longitude == info.Longitude && c.Latitude == info.Latitude);

        //    if (model != null)
        //    {
        //        //add the updated comment 
        //        model.Comments = info.Comments;
        //        await _informationContext.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new Exception("unable to find longitude and latitude");
        //    }

        //}

        [HttpGet]
        [Route("ReturnOneName")]
        public async Task<Models.Information> ReturnJustOneName(string x)
        {
            return await _informationConnection.GetBySingleName(x);
        }
        

        [HttpGet]
        public async Task<List<InformationDTO>> ReturnAll()
        {
     
           return await _informationConnection.GetAll();
        }
      


    }
}
