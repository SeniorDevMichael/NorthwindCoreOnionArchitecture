using Microsoft.EntityFrameworkCore;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Infrastructure.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //public IUnitOfWork UnitOfWork { set;  get; } //

        protected NorthwindContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(NorthwindContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();//
        }
                
        public Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, 
                                       params Expression<Func<TEntity, object>>[] includes)
        {
            return Get(filter, null, includes);
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter!=null)
            {
                query = query.Where(filter);
            }

            if (orderBy!=null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        //public async Task<TEntity> GetById(int Id, params Expression<Func<TEntity, object>>[] includes)
        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> expression,
                                           params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            //return await query.FirstOrDefaultAsync();
            return await query.Where(expression).FirstOrDefaultAsync();
            //return await _dbSet.FindAsync(Id);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression,
                                                  params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(expression).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task Add(TEntity entity)
        {
            //_context.Set<TEntity>().Add(entity);
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task Remove(int id)
        {
            _dbSet.Remove(await GetById(id));
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
           _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
           _dbSet.Update(entity);
        }
    }
}