using CrowSource.Conversion;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Numerics;
using WeatherApi.Data;
using WeatherApi.Models;
using Xunit.Abstractions; 

namespace WeatherApi.Repo
{
    public class InformationConnection : IRepo
    {
        private readonly InformationContext _context;
       
        public InformationConnection(InformationContext context)
        {
            _context = context;
            
        }
        public async Task<List<InformationDTO>> GetAllFoodTrucks()
        {
            var informationDTOs =  _context.Informations.Select(i => InformationMapper.MaptoDTO(i)).ToList();
            return informationDTOs;
        }


        public IEnumerable<InformationDTO> SearchFoodTruckName(string FoodTruckName)
        {

            var informationsList = _context.Informations.Where(x => x.Comments == FoodTruckName);
          
            if (informationsList is null)
            {
                throw new Exception($"the value of {nameof(FoodTruckName)} cannot be null");  
            }
            if (!informationsList.Any())
            {
                throw new CustomException($"the value of {nameof(FoodTruckName)} does not exists");
            }
            var InformationDTO = informationsList.Select(i => InformationMapper.MaptoDTO(i));
         
            return InformationDTO;
        }

       


        public async Task<Models.Information?> PostFoodTruck(InformationDTO infoDTO)
        {
            var info = InformationMapper.MapToInformationModel(infoDTO);
            info.Guid = Guid.NewGuid();
            info.DateTime = DateTime.Now.ToString();

            var add = await _context.Informations.AddAsync(info);
            await _context.SaveChangesAsync(true);

            return info;
        }


        public async Task DeleteFoodTruck(Guid guid)
        {
                var searchByGuid = _context.Informations.Single(x => x.Guid == guid);
                  _context.Remove(searchByGuid);
                 await _context.SaveChangesAsync();
        
        }

    


    }
}
