using System.Linq.Expressions;
using Domain.Dto.Pagination;
using Domain.Dto.Product;
using Domain.Entity;
using Services.Abstract.Base;

namespace Service.Abstract;

public interface IProductService : IBaseService<ProductDto>
{
    Task<PaginatedResult<ProductDto>> GetPageWithIncludeAsync(PagedRequest query, CancellationToken cancellationToken,
        params Expression<Func<Product, object>>[] includeProperties);

    Task<IEnumerable<string>> GetAllManufacturersAsync();
}