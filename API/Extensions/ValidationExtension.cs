using API.Models;
using API.Validation;
using Domain.Dto.Auth;
using FluentValidation;

namespace API.Extensions;

public static class ValidationExtension
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AuthRequest>, AuthRequestValidator>();
        services.AddScoped<IValidator<RegistrationModel>, RegistrationModelValidator>();
        services.AddScoped<IValidator<CartItemModel>, CartItemModelValidator>();
        services.AddScoped<IValidator<CategoryModel>, CategoryModelValidator>();
        services.AddScoped<IValidator<ProductModel>, ProductModelValidator>();
    }
}