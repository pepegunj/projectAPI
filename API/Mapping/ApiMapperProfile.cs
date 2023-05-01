using System.Linq.Dynamic.Core;
using API.Models;
using AutoMapper;
using Domain.Dto.Category;
using Domain.Dto.Customer;
using Domain.Dto.Product;
using Domain.Dto.ShoppingCart;
using Domain.Dto.User;
using Domain.Entity;

namespace API.Mapping;

public class ApiMapperProfile : Profile
{
    public ApiMapperProfile()
    {
        CreateMap<ProductModel, ProductDto>().ReverseMap();

        CreateMap<CategoryModel, CategoryDto>().ReverseMap();

        CreateMap<UserModel, UserDto>().ReverseMap();

        CreateMap<CustomerModel, CustomerDto>().ReverseMap();

        CreateMap<PagedResult<Product>, PagedResult<ProductDto>>().ReverseMap();

        CreateMap<PagedResult<ProductModel>, PagedResult<ProductDto>>().ReverseMap();

        CreateMap<ShoppingCartModel, ShoppingCartDto>().ForMember(x => x.CartItems, y => y.MapFrom(z => z.CartItems))
            .ReverseMap();

        CreateMap<CartItemDto, CartItemModel>().ReverseMap();

        CreateMap<CategoryDto, CategoryModel>().ReverseMap();

        CreateMap<UserProfileModel, UserDto>().ReverseMap();
    }
}