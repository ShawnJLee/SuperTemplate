using System;
using System.Data.Entity;
using System.Linq;
using SuperTemplate.Core.Entities;
using SuperTemplate.Core.Repository;

namespace SuperTemplate.EF.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SuperContext _context;
        private readonly IDbSet<TEntity> _entities;

        public Repository(SuperContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _entities.AsQueryable();
        }

        public void Insert(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _entities.Find(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
