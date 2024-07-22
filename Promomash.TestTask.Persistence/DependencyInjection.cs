using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promomash.TestTask.Domain.Contexts;
using Promomash.TestTask.Persistence.DatabaseContext;

namespace Promomash.TestTask.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<TestTaskContext>(o =>
                    o.UseSqlServer(configuration.GetConnectionString("TestTaskConnection"))
                )
                .AddScoped<IReadOnlyTestTaskContext, TestTaskContext>();
    }
}
