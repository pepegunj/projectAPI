using API.Controllers.Base;
using API.Models;
using AutoMapper;
using Domain.Dto.ShoppingCart;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace API.Controllers;

[ApiController]
[Route("cartItem")]
public class CartItemController : BaseController
{
    private readonly ICartItemService _cartItemService;
    private readonly IMapper _mapper;
    private readonly IValidator<CartItemModel> _validator;

    public CartItemController(ICartItemService cartItemService, IMapper mapper, IValidator<CartItemModel> validator)
    {
        _validator = validator;
        _cartItemService = cartItemService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<CartItemModel> AddCartItem([FromBody] CartItemModel model)
    {
        model.CustomerId = GetUserId();
        await _validator.ValidateAndThrowAsync(model);
        var result = _mapper.Map<CartItemDto>(model);
        await _cartItemService.AddAsync(result);
        return model;
    }

    [HttpDelete]
    public async Task<bool> DeleteCartItem([FromQuery] int cartItemId, int issuerId)
    {
        return await _cartItemService.RemoveAsync(cartItemId, issuerId);
    }

    [HttpGet]
    public async Task<IEnumerable<CartItemModel>> GetCartItemsByCartId()
    {
        var id = GetUserId();
        var result = await _cartItemService.getCartItemsByCartIdAsync(id);
        return _mapper.Map<IEnumerable<CartItemModel>>(result);
    }
}