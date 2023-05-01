using System.Linq.Expressions;
using AutoMapper;
using Data.Repositories.Abstract;
using Domain.Dto.Pagination;
using Domain.Dto.Product;
using Domain.Entity;
using Service.Abstract;

namespace Services.Implementation;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(ProductDto entity)
    {
        var product = _mapper.Map<Product>(entity);
        await _productRepository.AddAsync(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<ProductDto>>(products);
        return result;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> RemoveAsync(int id, int issuerId)
    {
        return await _productRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(ProductDto entity)
    {
        var product = _mapper.Map<Product>(entity);
        await _productRepository.UpdateAsync(product);
    }

    public async Task<PaginatedResult<ProductDto>> GetPageWithIncludeAsync(PagedRequest query,
        CancellationToken cancellationToken, params Expression<Func<Product, object>>[] includeProperties)
    {
        var pagedPosts = await _productRepository.GetPagedData(query, cancellationToken, includeProperties);

        return _mapper.Map<PaginatedResult<ProductDto>>(pagedPosts);
    }

    public async Task<PaginatedResult<ProductDto>> GetPageAsync(PagedRequest query, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetPagedData(query, cancellationToken);
        return _mapper.Map<PaginatedResult<ProductDto>>(result);
    }

    public async Task<IEnumerable<string>> GetAllManufacturersAsync()
    {
        return await _productRepository.GetAllManufacturersAsync();
    }

    //public Task<List<ProductModel>> 
}