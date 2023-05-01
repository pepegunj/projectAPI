using Data.Repositories.Abstract;
using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Implementation;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
    }
}