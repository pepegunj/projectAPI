using API.Controllers.Base;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace API.Controllers;

[ApiController]
[Route("ShoppingCart")]
public class ShoppingCartController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("active")]
    public async Task<ShoppingCartModel> GetActiveShoppingCartByUserId()
    {
        var id = GetUserId();
        var result = await _shoppingCartService.GetActiveShoppingCartAsync(id);
        return _mapper.Map<ShoppingCartModel>(result);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IEnumerable<ShoppingCartModel>> GetAllShoppingCartsById()
    {
        var id = GetUserId();
        var result = await _shoppingCartService.GetAllShoppingCartsByIdAsync(id);
        return _mapper.Map<IEnumerable<ShoppingCartModel>>(result);
    }

    [HttpPatch]
    public async Task BillCartById()
    {
        var id = GetUserId();
        await _shoppingCartService.BillCartByIdAsync(id);
    }
}