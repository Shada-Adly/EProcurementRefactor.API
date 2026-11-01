using EProcurementRefactor.Domain.Entities;
using System.Linq.Expressions;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IGenericPackagesRepo<T> where T : class
    {
        Task AddAsync(T entity);
        Task<int> FindMaxId(Expression<Func<T,int>> condition);
        Task<int> GetMaxIdPyParameter(
           Expression<Func<T, bool>> condition,
           Expression<Func<T, int>> fromColumn);
        Task AddRangeAsync(List<T> list);
    }
}
