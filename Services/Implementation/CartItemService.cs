using AutoMapper;
using Data.Repositories.Abstract;
using Domain.Dto.Pagination;
using Domain.Dto.ShoppingCart;
using Domain.Entity;
using Services.Abstract;

namespace Services.Implementation;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepositroy;
    private readonly IShoppingCartService _shoppingCartService;

    public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper,
        IProductRepository productRepository, IShoppingCartService shoppingCartService)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _productRepositroy = productRepository;
        _shoppingCartService = shoppingCartService;
    }

    public async Task AddAsync(CartItemDto entity)
    {
        var productFromDb = await _productRepositroy.GetByIdAsync(entity.ProductId);
        var shoppingCartFromDb = await _shoppingCartService.GetActiveShoppingCartAsync(entity.CustomerId);
        var result = _mapper.Map<CartItem>(entity);
        result.Price = result.Quantity * productFromDb.Price;
        result.ShoppingCartId = shoppingCartFromDb.Id;
        await _cartItemRepository.AddAsync(result);
    }

    public async Task<IEnumerable<CartItemDto>> GetAllAsync()
    {
        var result = await _cartItemRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CartItemDto>>(result);
    }

    public async Task<CartItemDto> GetByIdAsync(int id)
    {
        var result = await _cartItemRepository.GetByIdAsync(id);
        return _mapper.Map<CartItemDto>(result);
    }

    public async Task<IEnumerable<CartItemDto>> getCartItemsByCartIdAsync(int id)
    {
        var result = await _cartItemRepository.GetAllCartItemsByCartId(id);
        return _mapper.Map<IEnumerable<CartItemDto>>(result);
    }

    public async Task<PaginatedResult<CartItemDto>> GetPageAsync(PagedRequest query,
        CancellationToken cancellationToken)
    {
        var result = await _cartItemRepository.GetPagedData(query, cancellationToken);
        return _mapper.Map<PaginatedResult<CartItemDto>>(result);
    }

    public async Task<bool> RemoveAsync(int id, int issuerId)
    {
        return await _cartItemRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(CartItemDto entity)
    {
        var result = _mapper.Map<CartItem>(entity);
        await _cartItemRepository.UpdateAsync(result);
    }
}