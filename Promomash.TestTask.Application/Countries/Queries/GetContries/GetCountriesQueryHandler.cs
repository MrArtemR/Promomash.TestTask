using MediatR;
using Promomash.TestTask.Application.Commons;
using Promomash.TestTask.Domain.Contexts;
using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Application.Countries.Queries.GetContries
{
    internal class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, PagingCollection<CountriesResponse>>
    {
        private readonly IReadOnlyTestTaskContext _context;

        public GetCountriesQueryHandler(IReadOnlyTestTaskContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<PagingCollection<CountriesResponse>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            PagingCollection<CountryEntity> countries = await _context.Countries
                .GetPageAsync(request.Filter.Offset, request.Filter.Count, cancellationToken);

            return new PagingCollection<CountriesResponse>(
                countries.Entities.Select(c => new CountriesResponse(c.Id, c.Name)),
                countries.Offset, 
                countries.TotalCount);
        }
    }
}
