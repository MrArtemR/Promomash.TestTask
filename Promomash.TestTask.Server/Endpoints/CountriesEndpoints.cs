using MediatR;
using Promomash.TestTask.Application.Commons;
using Promomash.TestTask.Application.Countries.Queries.GetContries;
using Promomash.TestTask.Application.Provinces.Queries.GetProvinces;
using Promomash.TestTask.Server.Common;
using Promomash.TestTask.Server.Models.Responses;

namespace Promomash.TestTask.Server.Endpoints
{
    public static class CountriesEndpoints
    {
        public static WebApplication MapCountries(this WebApplication app)
        {
            //Должно быть /api/v1/countries но не удалось подружить с ангуляр
            RouteGroupBuilder groupBuilder = app.MapGroup("/weatherforecast/countries")
                                                .WithTags("Countries");

            _ = groupBuilder.MapGet(string.Empty, async (IMediator mediator,
                                                         CancellationToken cancellationToken,
                                                         int offset = 0,
                                                         int count = int.MaxValue) =>
            {
                GetCountriesQuery query = new(new GetCountriesFilter(offset, count));
                PagingCollection<CountriesResponse> result = await mediator.Send(query, cancellationToken);

                //по идее можно использовать маппер
                return TypedResults.Ok(new PagingCollection<PagingCountriesResponse>(
                    result.Entities.Select(e => new PagingCountriesResponse(e.Id, e.Name)), result.Offset, result.TotalCount));
            })
            .Produces<PagingCollection<PagingCountriesResponse>>(StatusCodes.Status200OK)
            .Produces<ErrorResult>(StatusCodes.Status400BadRequest);

            return app;
        }
    }
}
