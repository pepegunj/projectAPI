using Service.Abstract;
using Services.Abstract;
using Services.Abstract.Auth;
using Services.Implementation;
using Services.Implementation.Auth;

namespace API.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IShoppingCartService, ShoppingCartService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAuthenticationService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICartItemService, CartItemService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}