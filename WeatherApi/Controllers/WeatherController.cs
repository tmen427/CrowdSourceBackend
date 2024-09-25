


using CrowSource.Conversion;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using WeatherApi.Data;
using WeatherApi.Filters;
using WeatherApi.Models;
using WeatherApi.Repo;

namespace WeatherApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WeatherController : Controller
    {

      
        private readonly IRepo _informationConnection;

        public WeatherController(IRepo informationConnection)
        {
            _informationConnection = informationConnection;

        }


        
        [HttpPost]
        [Route("Post")]
        public  async Task<Models.Information?> Post(InformationDTO infoDTO)
        {
                          
               return await _informationConnection.PostFoodTruck(infoDTO);    
         
        }


       // [MyFirstFilter("500")]
      
        //[ProducesResponseType(StatusCodes.Status200OK)]
       // [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet]
        [Route("SearchFoodTruckName")]
        public IEnumerable<InformationDTO> Search(string name)
        { 
                var getName = _informationConnection.SearchFoodTruckName(name);
                return getName; 
        }



        [HttpDelete]
        [Route("DeleteFoodTruck")]
        public async Task Deletek(Guid guid)
        {
              await _informationConnection.DeleteFoodTruck(guid);

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
        //        await _informationContext.SaveChangesAsync();l
        //    }
        //    else
        //    {
        //        throw new Exception("unable to find longitude and latitude");
        //    }

        //}



        [HttpGet]
        [Route("GetAllFoodTrucks")]  
        public async Task<List<InformationDTO>> GetAll()
        {
           var foodtrucks = await _informationConnection.GetAllFoodTrucks();
           return foodtrucks; 
        }
      


    }
}
