using MyMovieApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyMovieApi.Core.Entities;
using System.Linq.Expressions;

namespace MyMovieApi.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            query = GetWithIncludes(query, includes);
            query = query.Where(e => e.Id == id);
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }


        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IQueryable<TEntity> GetWithIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return query;
        }
    }
}