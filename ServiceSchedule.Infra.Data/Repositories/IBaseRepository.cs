using System.Linq.Expressions;

namespace ServiceSchedule.Infra.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        Task<TEntity?> GetByIDAsync(object id);

        Task InsertAsync(TEntity entity);

        Task DeleteAsync(object id);

        Task DeleteAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }

}
