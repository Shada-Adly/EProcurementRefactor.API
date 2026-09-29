using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EProcurementRefactor.Infrastructure.Reposetories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _set;
        public GenericRepository(EprocurementDbContext context)
        {
            _set = context.Set<T>();
        }
        public async Task<T?> FindByFirstOrDefault(
            Expression<Func<T, bool>> condition , 
            CancellationToken cancellationToken)
        {
            if (condition is not null)
                return  await _set.FirstOrDefaultAsync(condition, cancellationToken);

            return await _set.FirstOrDefaultAsync(cancellationToken);
        }
    }
}