namespace EProcurementRefactor.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransaction(CancellationToken cancellationToken);
        Task CommitTransaction(CancellationToken cancellationToken);
        Task RollBackTransaction(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
