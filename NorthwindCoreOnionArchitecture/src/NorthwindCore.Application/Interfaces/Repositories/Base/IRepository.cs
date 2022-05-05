using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;//
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
                                params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetById(int Id);
        Task<TEntity> GetById(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);

        Task Remove(int id);
        Task RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        //IUnitOfWork UnitOfWork { set; get; }
    }
}