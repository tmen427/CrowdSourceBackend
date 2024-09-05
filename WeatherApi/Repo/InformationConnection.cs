using CrowSource.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WeatherApi.Data;
using WeatherApi.Models;

namespace WeatherApi.Repo
{
    public class InformationConnection : IRepo
    {
        private readonly InformationContext _context; 
        public InformationConnection(InformationContext context)
        {
            _context = context; 
        }
        public async Task<List<InformationDTO>> GetAll()
        {
            var informationDTOs =  _context.Informations.Select(i => InformationMapper.MaptoDTO(i)).ToList();
            return informationDTOs;
        }

        public IEnumerable<InformationDTO> GetByName(string name)
        {
            var informationsList = _context.Informations.Where(x => x.Comments == name);
            var convertToDTO = informationsList.Select(i => InformationMapper.MaptoDTO(i));
            return convertToDTO;
        }

       


        public async Task<Models.Information?> Post(InformationDTO infoDTO)
        {
            var info = InformationMapper.MapToInformationModel(infoDTO);
            info.Guid = Guid.NewGuid();
            info.DateTime = DateTime.Now.ToString();

            var add = await _context.Informations.AddAsync(info);
            await _context.SaveChangesAsync(true);

            return info;
        }


        public async Task DeleteByGuid(Guid guid)
        {
            var searchByGuid = _context.Informations.Single(x => x.Guid == guid);
            _context.Remove(searchByGuid);
            await _context.SaveChangesAsync();
        }

        //just return 1 for testing purposes here 
        //
        public async Task<Models.Information> GetBySingleName(string name)
        {
            var information = await _context.Informations.FirstOrDefaultAsync(x => x.Comments == name);
            return information;
        }


    }
}
