using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity FirstOrDefault();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        int Count();
    }
}
