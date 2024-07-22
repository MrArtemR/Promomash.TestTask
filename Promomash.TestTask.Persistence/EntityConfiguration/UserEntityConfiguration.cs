using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Persistence.EntityConfiguration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.ComplexProperty(e => e.Login, l => l.IsRequired()); 
        }
    }
}
