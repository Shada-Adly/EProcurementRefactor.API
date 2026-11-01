using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EProcurementRefactor.Infrastructure.Reposetories
{
    public class GenericPackageRepo<T> : IGenericPackagesRepo<T> where T : class
    {
        private readonly DbSet<T> _set;
        private readonly IUnitOfWork _unitOfWork;
        public GenericPackageRepo(
            EprocurementDbContext eprocurementDbContext,
            IUnitOfWork unitOfWork)
        {
            _set = eprocurementDbContext.Set<T>();
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(T entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

           await _set.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException("There are no elements to add in package deatils .");
            }
           await _set.AddRangeAsync(list);
        }

        public async Task<int> FindMaxId(Expression<Func<T,int>> condition)
        {
            var maxId = await _set.AnyAsync()
                ? await _set.MaxAsync(condition)
                : 0;
            return maxId;
        }
        public async Task<int> GetMaxIdPyParameter(
        Expression<Func<T, bool>> condition,
        Expression<Func<T, int>> fromColumn)
        {
            var query = _set.Where(condition);

            int maxIdPyParameter = await query.AnyAsync()
                ? await query.MaxAsync(fromColumn)
                : 0;

            return maxIdPyParameter;
        }
    }
}
