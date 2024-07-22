using MediatR;
using Promomash.TestTask.Application.Provinces.Queries.GetProvinces;
using Promomash.TestTask.Server.Common;
using Promomash.TestTask.Server.Models.Responses;

namespace Promomash.TestTask.Server.Endpoints
{
    public static class ProvincesEndpoints
    {
        public static WebApplication MapProvinces(this WebApplication app)
        {
            //Должно быть /api/v1/countries но не удалось подружить с ангуляр
            RouteGroupBuilder groupBuilder = app.MapGroup("/weatherforecast/countries")
                                                .WithTags("Provinces");

            _ = groupBuilder.MapGet("/{id:int}/provinces", async (int id,
                                                                  IMediator mediator,
                                                                  CancellationToken cancellationToken) =>
            {
                GetProvincesQuery query = new(id);
                IEnumerable<ProvincesResponce> result = await mediator.Send(query, cancellationToken);

                //по идее можно использовать маппер
                return TypedResults.Ok(result.Select(e => new ProvincesResponse(e.Id, e.Name)));
            })
            .Produces< ProvincesResponse> (StatusCodes.Status200OK)
            .Produces<ErrorResult>(StatusCodes.Status400BadRequest);

            return app;
        }
    }
}
