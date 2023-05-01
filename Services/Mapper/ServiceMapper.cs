using AutoMapper;
using Domain.Dto.Auth;
using Domain.Dto.Category;
using Domain.Dto.Customer;
using Domain.Dto.Pagination;
using Domain.Dto.Product;
using Domain.Dto.ShoppingCart;
using Domain.Dto.User;
using Domain.Entity;

namespace Services.Mapper;

public class ServiceMapper : Profile
{
    public ServiceMapper()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, AuthResponse>();
        CreateMap<User, AuthRequest>().ReverseMap();
        CreateMap<RegistrationModel, UserDto>();
        CreateMap<RegistrationModel, CustomerDto>();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        /*            CreateMap<PagedResult<Product>, PagedResult<ProductDto>>().ReverseMap();
        */
        CreateMap<CartItem, CartItemDto>()
            .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.ProductName))
            .ForMember(x => x.ProductDescription, y => y.MapFrom(x => x.Product.ProductDescription))
            .ForMember(x => x.iconURL, y => y.MapFrom(x => x.Product.IconURL))
            .ForMember(x => x.CustomerId, y => y.MapFrom(x => x.ShoppingCart.CustomerId))
            .ForMember(x => x.Category, y => y.MapFrom(x => x.Product.Category));
        CreateMap<CartItemDto, CartItem>();
        CreateMap<ShoppingCart, ShoppingCartDto>().ForMember(x => x.CartItems, y => y.MapFrom(x => x.CartItems))
            .ReverseMap();
        CreateMap<PaginatedResult<CartItem>, PaginatedResult<CartItemDto>>().ReverseMap();
        CreateMap<PaginatedResult<Product>, PaginatedResult<ProductDto>>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}