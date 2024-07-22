using Promomash.TestTask.Domain.Common;

namespace Promomash.TestTask.Application.Interfaces
{
    public interface IUserManager
    {
        Result<string> HashPassword(string password);
    }
}
