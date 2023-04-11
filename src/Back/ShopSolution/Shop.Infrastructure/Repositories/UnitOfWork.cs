using Shop.Application.Persistence;
using Shop.Infrastructure.Context;
using System.Collections;

namespace Shop.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;
        private readonly ShopDbContext _context;

        public UnitOfWork(ShopDbContext context)
        {
            _context = context;
        }


        public async Task<int> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// lien entre l'entity et une instance du repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IBaseRepository<T> Repository<T>() where T : class
        {
            if (_repositories is null)
                _repositories = new Hashtable();

            string? type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<T>)_repositories[type]!;
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
