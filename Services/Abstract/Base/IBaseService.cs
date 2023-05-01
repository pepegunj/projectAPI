using Domain.Dto.Pagination;

namespace Services.Abstract.Base;

public interface IBaseService<TEntity> where TEntity : class
{
    public Task AddAsync(TEntity entity);

    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task<TEntity> GetByIdAsync(int id);

    public Task<bool> RemoveAsync(int id, int issuerId);
    Task<PaginatedResult<TEntity>> GetPageAsync(PagedRequest query, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity);
}