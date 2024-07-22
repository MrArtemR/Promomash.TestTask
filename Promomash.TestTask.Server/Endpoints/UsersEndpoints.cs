using MediatR;
using Promomash.TestTask.Application.Users.Commands.AddUser;
using Promomash.TestTask.Server.Common;
using Promomash.TestTask.Server.Models.Requests;

namespace Promomash.TestTask.Server.Endpoints
{
    public static class UsersEndpoints
    {
        public static WebApplication MapUsers(this WebApplication app)
        {
            //Должно быть /api/v1/users но не удалось подружить с ангуляр
            RouteGroupBuilder groupBuilder = app.MapGroup("/weatherforecast/users")
                                                .WithTags("Users");

            _ = groupBuilder.MapPost(string.Empty, async (AddUserRequest request,
                                                         IMediator mediator,
                                                         CancellationToken cancellationToken) =>
            {
                //по идее можно использовать маппер
                AddUserCommand command = new(request.Login, request.Password, request.CountryId, request.ProvinceId);
                int result = await mediator.Send(command, cancellationToken);

                return TypedResults.Ok(result);
            })
            .Produces<int>(StatusCodes.Status200OK)
            .Produces<ErrorResult>(StatusCodes.Status400BadRequest);

            return app;
        }
    }
}
