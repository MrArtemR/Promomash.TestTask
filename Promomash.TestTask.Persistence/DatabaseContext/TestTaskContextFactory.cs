using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Promomash.TestTask.Persistence.DatabaseContext
{
    internal class TestTaskContextFactory : IDesignTimeDbContextFactory<TestTaskContext>
    {
        public TestTaskContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestTaskContext>();
            optionsBuilder.UseSqlServer("Data Source=!!!!!!!;Database=TestTask;User Id=!!;Password=!!!!");
            return new TestTaskContext(optionsBuilder.Options);
        }
    }
}
