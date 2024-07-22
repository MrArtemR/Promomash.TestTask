using MediatR;

namespace Promomash.TestTask.Application.Provinces.Queries.GetProvinces
{
    public record GetProvincesQuery(int? CountryId) : IRequest<IEnumerable<ProvincesResponce>>;
}
