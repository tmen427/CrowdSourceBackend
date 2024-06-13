using WeatherApi.Models;
using Microsoft.EntityFrameworkCore; 
namespace WeatherApi.Data


{
    public class InformationContext : DbContext
    {
            public InformationContext(DbContextOptions<InformationContext> options) : base(options) { }
    
            public DbSet<Information> Informations { get; set; }
    
    }
}
