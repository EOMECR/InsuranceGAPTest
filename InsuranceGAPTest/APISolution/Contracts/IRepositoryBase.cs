using System;
using System.Linq;
using System.Linq.Expressions;

namespace APISolution.Contracts
{
    public interface IRepositoryBase<T>
    {
        public IQueryable<T> FindAll();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
