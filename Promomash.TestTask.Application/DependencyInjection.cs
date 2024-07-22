using Microsoft.Extensions.DependencyInjection;
using Promomash.TestTask.Application.Interfaces;
using Promomash.TestTask.Application.Managers;
using System.Reflection;

namespace Promomash.TestTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IPasswordValidator, PasswordValidator>()
                .AddScoped<IUserManager, UserManager>()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
