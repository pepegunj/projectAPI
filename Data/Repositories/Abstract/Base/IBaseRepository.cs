using System.Linq.Expressions;
using Domain.Abstract;
using Domain.Dto.Pagination;

namespace Data.Repositories.Abstract.Base;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> DeleteAsync(int id);

    Task<PaginatedResult<TEntity>> GetPagedData(PagedRequest pagedRequest, CancellationToken cancellationToken,
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task SaveChangesAsync();
}