using System.Threading.Tasks;

namespace Test2.Domain
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}