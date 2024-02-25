using GardenConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GardenConsoleAPI.IntegrationTests.NUnit
{
    public class TestPlantsDbContext : PlantsDbContext
    {
        public TestPlantsDbContext()
            : base(new ConfigurationBuilder().AddInMemoryCollection().Build())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("TestDatabase");
            }
        }
    }
}
