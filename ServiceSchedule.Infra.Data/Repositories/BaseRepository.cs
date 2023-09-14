using Microsoft.EntityFrameworkCore;
using ServiceSchedule.Infra.Data.Context;
using ServiceSchedule.Infra.Data.Repositories;
using System.Linq.Expressions;

namespace Raizen.JDC.Letters.Infra.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal ServiceScheduleContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(ServiceScheduleContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => dbSet.AsQueryable();

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) => GetAll().Where(expression);

        public virtual async Task<TEntity?> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            context.SaveChanges();
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id) ?? throw new Exception();
            await DeleteAsync(entityToDelete);
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}