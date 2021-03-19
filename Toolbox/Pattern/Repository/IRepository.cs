using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Pattern.Repository
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        // CRUD Method
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();

        TKey Insert(TEntity entity);

        bool Update(TKey key, TEntity entity);

        bool Delete(TKey key);
        bool Delete(TEntity entity)
        {
            return Delete(entity.Id);
        }
    }
}
