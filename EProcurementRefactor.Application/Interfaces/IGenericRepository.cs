using System.Linq.Expressions;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T?> FindByFirstOrDefault(
            Expression<Func<T, bool>> condition ,
            CancellationToken cancellationToken);
    }
}
