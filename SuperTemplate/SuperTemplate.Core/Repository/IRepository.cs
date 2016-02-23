using System;
using System.Linq;
using SuperTemplate.Core.Entities;

namespace SuperTemplate.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetQuery();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
    }
}
