using MediatR;
using Promomash.TestTask.Application.Commons;

namespace Promomash.TestTask.Application.Countries.Queries.GetContries
{
    public record GetCountriesQuery(GetCountriesFilter Filter) : IRequest<PagingCollection<CountriesResponse>>;
}
