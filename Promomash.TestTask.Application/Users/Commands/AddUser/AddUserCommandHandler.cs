using MediatR;
using Microsoft.EntityFrameworkCore;
using Promomash.TestTask.Application.Interfaces;
using Promomash.TestTask.Domain.Common;
using Promomash.TestTask.Domain.Entities;
using Promomash.TestTask.Domain.Values;
using Promomash.TestTask.Persistence.DatabaseContext;

namespace Promomash.TestTask.Application.Users.Commands.AddUser
{
    internal class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly TestTaskContext _context;
        private readonly IUserManager _userManager;

        public AddUserCommandHandler(TestTaskContext context, IUserManager userManager)
        {
            _context = context ?? throw new ApplicationException(nameof(context));
            _userManager = userManager ?? throw new ApplicationException(nameof(userManager));
        }

        public async Task<int> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            UserEntity user = await _context.Users.SingleOrDefaultAsync(u => u.Login.Value == command.Login, cancellationToken);
            if (user is not null)
                throw new AppErrorException("A user with this login already exists", ErrorCode.UserWithThisLoginAlreadyExists);

            CountryEntity country = await _context.Countries.SingleOrDefaultAsync(c => c.Id == command.CountryId, cancellationToken) ??
                throw new AppErrorException("Country not found", ErrorCode.CountryNotFound);

            ProvinceEntity province = await _context.Provinces.SingleOrDefaultAsync(p => p.Id == command.ProvinceId) ??
                throw new AppErrorException("Province not found", ErrorCode.ProvinceNotFounde);

            Result<Login> loginCreationResult = Login.Create(command.Login);
            if (loginCreationResult.IsSuccess is false)
            {
                throw new AppErrorException(loginCreationResult.Error, loginCreationResult.ErrorCode!.Value);
            }

            Result<string> hashPasswordResult = _userManager.HashPassword(command.Password);
            if (hashPasswordResult.IsSuccess is false)
            {
                throw new AppErrorException(hashPasswordResult.Error, hashPasswordResult.ErrorCode.Value);
            }

            user = new UserEntity(loginCreationResult.Value, hashPasswordResult.Value, country.Id, province.Id);
            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
