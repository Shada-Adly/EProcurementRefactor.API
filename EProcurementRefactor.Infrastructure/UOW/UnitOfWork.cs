using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EProcurementRefactor.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EprocurementDbContext _dbContext;
        private IDbContextTransaction transaction;
        public UnitOfWork(EprocurementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransaction(CancellationToken cancellationToken)
        {
            if(transaction is not null)
            {
                throw new InvalidOperationException("Transaction still in Progress");
            }
            transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransaction(CancellationToken cancellationToken)
        {
            if(transaction is null)
            {
                throw new InvalidOperationException("There is no Transactions");
            }

            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
            transaction = null;
        }

        public async Task RollBackTransaction(CancellationToken cancellationToken)
        {
            if (transaction is null)
            {
                throw new InvalidOperationException("There is no Transactions");
            }
            await transaction.RollbackAsync(cancellationToken);
            await transaction.DisposeAsync();
            transaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var connection = _dbContext.Database.GetDbConnection();

            Console.WriteLine($"Database: {connection.Database}");
            Console.WriteLine($"Server: {connection.DataSource}");
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
