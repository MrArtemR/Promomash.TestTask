using Microsoft.EntityFrameworkCore;

namespace Promomash.TestTask.Application.Commons
{
    public class PagingCollection<TEntity>
    {
        public IEnumerable<TEntity> Entities { get; }
        public int Offset { get; }
        public int TotalCount { get; }

        public PagingCollection(IEnumerable<TEntity> entities, int offset, int totalCount)
        {
            Entities = entities ?? throw new ArgumentNullException(nameof(entities));
            Offset = offset;
            TotalCount = totalCount;
        }
    }

    public static class PagingConllectionExtensions
    {
        public static async Task<PagingCollection<TEntity>> GetPageAsync<TEntity>(this IQueryable<TEntity> source,
            int offset, int count, CancellationToken cancellationToken)
            where TEntity : class
        {
            var totalCount = await source.CountAsync(cancellationToken);
            if (totalCount == 0)
            {
                return new PagingCollection<TEntity>([], 0, 0);
            }

            if (offset > 0)
            {
                source = source.Skip(offset);
            }

            if (count != int.MaxValue)
            {
                source = source.Take(count);
            }

            var entities = await source.ToListAsync(cancellationToken);

            return new PagingCollection<TEntity>(entities, offset, totalCount);
        }
    }
}
