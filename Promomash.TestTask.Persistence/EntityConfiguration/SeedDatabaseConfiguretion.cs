using Microsoft.EntityFrameworkCore;
using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Persistence.EntityConfiguration
{
    internal static class SeedDatabaseConfiguretion
    {
        public static ModelBuilder SeedDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryEntity>().HasData(new { Id = 1, Name = "Russia", Created = DateTime.UtcNow },
                                             new { Id = 2, Name = "Kazakhstan", Created = DateTime.UtcNow });
            modelBuilder.Entity<ProvinceEntity>().HasData(new { Id = 1, CountryId = 1, Name = "Moscow", Created = DateTime.UtcNow },
                                                          new { Id = 2, CountryId = 1, Name = "Sanct Peterburg", Created = DateTime.UtcNow },
                                                          new { Id = 3, CountryId = 2, Name = "Atyrau region", Created = DateTime.UtcNow },
                                                          new { Id = 4, CountryId = 2, Name = "Kostanay region", Created = DateTime.UtcNow });

            return modelBuilder;
        }
    }
}
