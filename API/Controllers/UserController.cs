using API.Controllers.Base;
using API.Models;
using AutoMapper;
using Domain.Dto.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using Services.Abstract;

namespace API.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IShoppingCartService _shoppingCartService;

        public UserController(IMapper mapper, IUserService userService, IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("/user")]
        public async Task<UserProfileModel> GetUserByIdAsync()
        {
            var userDto = await _userService.GetByIdAsync(GetUserId());
            return _mapper.Map<UserProfileModel>(userDto);
        }

        [HttpGet]
        [Route("/user/carts")]
        public async Task<IEnumerable<ShoppingCartModel>> GetUsersCarts()
        {
            var id = GetUserId();
            var carts = await _shoppingCartService.GetAllShoppingCartsByIdAsync(id);
            return _mapper.Map<IEnumerable<ShoppingCartModel>>(carts);
        }
    }
}