using Promomash.TestTask.Application.Interfaces;
using Promomash.TestTask.Domain.Common;

namespace Promomash.TestTask.Application.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPasswordValidator _passwordValidator;

        public UserManager(IPasswordHasher hasher, IPasswordValidator validator)
        {
            _passwordHasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
            _passwordValidator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public Result<string> HashPassword(string password)
        {
            bool isValid = _passwordValidator.Validate(password);
            if (isValid is false)
            {
                return Result<string>.Fail(ErrorCode.InvalidUserPassword, "Invalid user password");
            }

            return Result<string>.Ok(_passwordHasher.HashPassword(password));
        }
    }
}
