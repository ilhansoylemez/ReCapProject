using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity Entity)
        {
            using (TContext carContext = new TContext())
            {
                var addedEntity = carContext.Entry(Entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Delete(TEntity Entity)
        {
            using (TContext carContext = new TContext())
            {
                var addedEntity = carContext.Entry(Entity);
                addedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext carContext = new TContext())
            {
                return carContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext carContext = new TContext())
            {
                return filter == null ? carContext.Set<TEntity>().ToList() : carContext.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity Entity)
        {
            using (TContext carContext = new TContext())
            {
                var updatedEntity = carContext.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }
    }
}
