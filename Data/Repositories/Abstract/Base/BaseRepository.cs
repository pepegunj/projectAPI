using System.Linq.Expressions;
using Domain.Abstract;
using Domain.Dto.Pagination;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstract.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _db;

    public BaseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TEntity entity)
    {
        entity.RegistrationDate = DateTime.UtcNow;
        await _db.Set<TEntity>().AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _db.Remove(entity);
        await SaveChangesAsync();
        return true;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _db.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _db.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _db.Set<TEntity>().FindAsync(id);
        if (entity != null) return entity;
        throw new ArgumentException($"Entity with id :{id} does not exist");
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _db.Update(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<PaginatedResult<TEntity>> GetPagedData(PagedRequest pagedRequest,
        CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = IncludeProperties(includeProperties);

        return await query.CreatePaginatedResultAsync(pagedRequest, cancellationToken);
    }

    private IQueryable<TEntity> IncludeProperties(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> entities = _db.Set<TEntity>();

        foreach (var includeProperty in includeProperties) entities = entities.Include(includeProperty);

        return entities;
    }
}