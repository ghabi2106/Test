using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Test.Domain.IRepositories;
using Test.Infra.Data.Context;

namespace Test.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private TestContext _context;
        internal DbSet<TEntity> dbSet;
        public BaseRepository(TestContext context)
        {
            _context = context;
            this.dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual int Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return Save();
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return await SaveAsync();
        }

        public virtual int InsertRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
            return Save();
        }

        public virtual async Task<int> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await SaveAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            dbSet.Attach(entity);
            return await SaveAsync();
        }

        public virtual int Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            return Save();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            return await SaveAsync();
        }

        public virtual int DeleteRange(IEnumerable<TEntity> entity)
        {
            dbSet.RemoveRange(entity);
            return Save();
        }

        public virtual async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
            return await SaveAsync();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter = null)
        {
            return dbSet.Any(filter);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await dbSet.AnyAsync(filter);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return dbSet.Count(filter);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await dbSet.CountAsync(filter);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
