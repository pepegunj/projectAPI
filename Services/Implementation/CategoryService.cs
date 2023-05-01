using AutoMapper;
using Data.Repositories.Abstract;
using Domain.Dto.Category;
using Domain.Dto.Pagination;
using Domain.Entity;
using Services.Abstract;

namespace Services.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(CategoryDto entity)
    {
        await _categoryRepository.AddAsync(_mapper.Map<Category>(entity));
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(result);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var result = _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(result);
    }

    public async Task<bool> RemoveAsync(int id, int issuerId)
    {
        return await _categoryRepository.DeleteAsync(id);
    }

    public async Task<PaginatedResult<CategoryDto>> GetPageAsync(PagedRequest query,
        CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetPagedData(query, cancellationToken);
        return _mapper.Map<PaginatedResult<CategoryDto>>(result);
    }

    public async Task UpdateAsync(CategoryDto entity)
    {
        await _categoryRepository.UpdateAsync(_mapper.Map<Category>(entity));
    }
}