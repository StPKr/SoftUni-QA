using GardenConsoleAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GardenConsoleAPI.DataAccess
{
    public class PlantsDbContext : DbContext
    {
        public virtual DbSet<Plant> Plants { get; set; }


        public PlantsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public PlantsDbContext(IConfigurationRoot configurationRoot)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
