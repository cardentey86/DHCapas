using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL
{
    public interface IRepository<TEntity> where TEntity : Entity
    {

        Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters);
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByID(object id);
        void Insert(TEntity entity);
        Task<TEntity> Delete(int id);
        Task<TEntity> Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);


        //IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        //T Get(Func<T, bool> predicate);
        //void Add(T entity);
        //void Attach(T entity);
        //void Delete(T entity);
    }
}
