namespace Shop.Application.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : class;
        Task<int> CommitAsync();
    }
}
