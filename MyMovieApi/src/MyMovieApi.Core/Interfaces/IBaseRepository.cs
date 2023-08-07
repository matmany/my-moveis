using System.Linq.Expressions;

namespace MyMovieApi.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> GetByIdAsync(long id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        //Task<AsyncOutResult<IEnumerable<TEntity>, int>> GetAllAsync(int? take, int? offSet, string sortingProp, bool? asc);

    }
}