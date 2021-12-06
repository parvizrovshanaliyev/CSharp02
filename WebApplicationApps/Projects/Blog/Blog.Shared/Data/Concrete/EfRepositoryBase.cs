﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Shared.Data.Abstract;
using Blog.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Blog.Shared.Data.Concrete
{
    public class EfRepositoryBase<TEntity>: IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        #region fields

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        #endregion
        #region ctor

        public EfRepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        #endregion
        #region Implementation of IEntityRepository<TEntity>

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            // where 
            if (predicate is not null)
            {
                query = query.Where(predicate);
            }
            // left join
            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }


            return await query.ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async  Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _dbSet.Update(entity);});
        }

        public async  Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _dbSet.Remove(entity); });
        }

        #endregion
    }
}