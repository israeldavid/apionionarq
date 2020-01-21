using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string requesturl);
        //Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression);
        //Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        //Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        //Task<TEntity> CreateAsync(TEntity entity);
        //Task<TEntity> UpdateAsync(TEntity entity);
        //Task<TEntity> DeleteAsync(TEntity entity);
    }
}