using MediatR;
using Microsoft.EntityFrameworkCore;
using Promomash.TestTask.Domain.Contexts;
using Promomash.TestTask.Domain.Entities;

namespace Promomash.TestTask.Application.Provinces.Queries.GetProvinces
{
    internal class GetProvincesQueryHandler : IRequestHandler<GetProvincesQuery, IEnumerable<ProvincesResponce>>
    {
        private readonly IReadOnlyTestTaskContext _context;

        public GetProvincesQueryHandler(IReadOnlyTestTaskContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<ProvincesResponce>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ProvinceEntity> query = _context.Provinces;

            if (request.CountryId.HasValue)
            {
                query = query.Where(p => p.CountryId == request.CountryId.Value);
            }

            IEnumerable<ProvinceEntity> provinces = await query.ToArrayAsync(cancellationToken);

            return provinces.Select(p => new ProvincesResponce(p.Id, p.Name));
        }
    }
}
