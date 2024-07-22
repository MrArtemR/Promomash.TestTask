using MediatR;

namespace Promomash.TestTask.Application.Users.Commands.AddUser
{
    public record AddUserCommand(string Login, string Password, int CountryId, int ProvinceId) : IRequest<int>;
}
