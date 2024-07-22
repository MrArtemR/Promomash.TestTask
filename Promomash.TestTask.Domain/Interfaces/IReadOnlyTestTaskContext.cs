using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Domain.Contexts
{
    public interface IReadOnlyTestTaskContext
    {
        IQueryable<UserEntity> Users { get; }
        IQueryable<CountryEntity> Countries { get; }
        IQueryable<ProvinceEntity> Provinces { get; }
    }
}
