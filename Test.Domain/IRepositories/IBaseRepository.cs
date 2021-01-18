using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();

        public Task<List<TEntity>> GetAllAsync();

        public TEntity FindById(int id);

        public Task<TEntity> FindByIdAsync(int id);

        public int Insert(TEntity entity);

        public Task<int> InsertAsync(TEntity entity);

        public int InsertRange(IEnumerable<TEntity> entities);

        public Task<int> InsertRangeAsync(IEnumerable<TEntity> entities);

        public Task<int> UpdateAsync(TEntity entity);

        public int Delete(TEntity entity);

        public Task<int> DeleteAsync(TEntity entity);

        public int DeleteRange(IEnumerable<TEntity> entity);

        public Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities);

        public bool Exists(Expression<Func<TEntity, bool>> filter = null);

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null);

        public int Count(Expression<Func<TEntity, bool>> filter = null);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        public int Save();

        public Task<int> SaveAsync();
    }
}
