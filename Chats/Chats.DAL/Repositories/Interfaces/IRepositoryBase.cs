using System.Linq.Expressions;

namespace Chats.DAL.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>>? expression = null);
        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        void DeleteMultipleEntities(IEnumerable<T> entities);
    }
}
