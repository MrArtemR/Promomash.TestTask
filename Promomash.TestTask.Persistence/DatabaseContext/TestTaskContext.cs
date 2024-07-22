using Microsoft.EntityFrameworkCore;
using Promomash.TestTask.Domain.Contexts;
using Promomash.TestTask.Domain.Entities;
using Promomash.TestTask.Persistence.EntityConfiguration;

namespace Promomash.TestTask.Persistence.DatabaseContext
{
    public class TestTaskContext : DbContext, IReadOnlyTestTaskContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<ProvinceEntity> Provinces { get; set; }

        IQueryable<UserEntity> IReadOnlyTestTaskContext.Users => Users.AsNoTracking().AsQueryable();

        IQueryable<CountryEntity> IReadOnlyTestTaskContext.Countries => Countries.AsNoTracking().AsQueryable();

        IQueryable<ProvinceEntity> IReadOnlyTestTaskContext.Provinces => Provinces.AsNoTracking().AsQueryable();

        public TestTaskContext(DbContextOptions<TestTaskContext> oprions) : base(oprions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration())
                        .ApplyConfiguration(new CountryEntityConfiguration())
                        .ApplyConfiguration(new ProvinceEntityConfiguration())
                        .SeedDatabase();
        }
    }
}
