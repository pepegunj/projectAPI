using AutoMapper;
using Data.Repositories.Abstract;
using Domain;
using Domain.Dto.Pagination;
using Domain.Dto.ShoppingCart;
using Domain.Entity;
using Services.Abstract;

namespace Services.Implementation;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(ShoppingCartDto entity)
    {
        var result = _mapper.Map<ShoppingCart>(entity);
        await _shoppingCartRepository.AddAsync(result);
    }

    public async Task BillCartByIdAsync(int id)
    {
        var cart = await GetActiveShoppingCartAsync(id);
        await _shoppingCartRepository.BillCartByIdAsync(cart.Id);
    }

    public async Task<ShoppingCartDto> GetActiveShoppingCartAsync(int id)
    {
        var result =
            await _shoppingCartRepository.GetByCustomerIdAsync(x =>
                x.CustomerId == id && x.CartState == CartStates.Active);
        if (result.Any())
        {
            var toReturn = _mapper.Map<ShoppingCartDto>(result.First());
            toReturn.FullPrice = CalculateFullPrice(toReturn);
            return toReturn;
        }

        await AddAsync(new ShoppingCartDto { CustomerId = id, CartState = CartStates.Active });
        result = await _shoppingCartRepository.GetByCustomerIdAsync(x =>
            x.CustomerId == id && x.CartState == CartStates.Active);
        return _mapper.Map<ShoppingCartDto>(result.First());
    }

    public async Task<IEnumerable<ShoppingCartDto>> GetAllAsync()
    {
        var result = await _shoppingCartRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ShoppingCartDto>>(result);
    }

    public async Task<IEnumerable<ShoppingCartDto>> GetAllShoppingCartsByIdAsync(int id)
    {
        var result = await _shoppingCartRepository.GetByCustomerIdAsync(x => x.CustomerId == id);
        return _mapper.Map<IEnumerable<ShoppingCartDto>>(result);
    }

    public async Task<ShoppingCartDto> GetByIdAsync(int id)
    {
        var result = await _shoppingCartRepository.GetByIdAsync(id);
        return _mapper.Map<ShoppingCartDto>(result);
    }

    public async Task<PaginatedResult<ShoppingCartDto>> GetPageAsync(PagedRequest query,
        CancellationToken cancellationToken)
    {
        var result = await _shoppingCartRepository.GetPagedData(query, cancellationToken);
        return _mapper.Map<PaginatedResult<ShoppingCartDto>>(result);
    }

    public async Task<bool> RemoveAsync(int id, int issuerId)
    {
        return await _shoppingCartRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(ShoppingCartDto entity)
    {
        var result = _mapper.Map<ShoppingCart>(entity);
        await _shoppingCartRepository.UpdateAsync(result);
    }

    private double CalculateFullPrice(ShoppingCartDto cart)
    {
        double sum = 0;
        for (var i = 0; i < cart.CartItems.Count(); i++) sum += cart.CartItems.ElementAt(i).Price;
        return sum;
    }
}