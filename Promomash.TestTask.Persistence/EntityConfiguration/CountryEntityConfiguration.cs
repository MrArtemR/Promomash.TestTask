using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Persistence.EntityConfiguration
{
    internal class CountryEntityConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Countries");

            builder.HasIndex(u => u.Name).IsUnique();
        }
    }
}
