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
            _repositories ??= new Hashtable();

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

            // permet de ne pas appeler la méthode Finalize() pour cet objet lorsqu'il est ramassé.
            // La méthode Finalize() est utilisée pour effectuer des opérations de nettoyage 
            // avant que l'objet ne soit réellement supprimé de la mémoire.
            // Cependant, puisque nous avons déjà appelé Dispose() pour libérer les ressources, 
            // nous n'avons plus besoin de la méthode Finalize().
            // En appelant GC.SuppressFinalize(this), nous indiquons au garbage collector de l'ignorer.
            GC.SuppressFinalize(this);
        }
    }
}
