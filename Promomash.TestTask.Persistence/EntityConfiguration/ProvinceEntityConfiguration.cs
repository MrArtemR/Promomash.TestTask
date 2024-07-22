using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Persistence.EntityConfiguration
{
    internal class ProvinceEntityConfiguration : IEntityTypeConfiguration<ProvinceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            builder.ToTable("Provinces");

            builder.HasIndex(u => u.Name).IsUnique();
        }
    }
}
