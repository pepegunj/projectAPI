using System.Data;
using API.Models;
using Domain.Dto.Auth;
using FluentValidation;
using static Domain.Constants;

namespace API.Validation;

public class AuthRequestValidator : AbstractValidator<AuthRequest>
{
    public AuthRequestValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().NotNull().MinimumLength(USERNAME_MIN_LENGTH)
            .MaximumLength(USERNAME_MAX_LENGTH);
        RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(PASSWORD_MIN_LENGTH)
            .MaximumLength(USERNAME_MAX_LENGTH);
    }
}

public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
{
    public RegistrationModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().NotNull();
        RuleFor(x => x.LastName).NotEmpty().NotNull();
        RuleFor(x => x.UserName).NotEmpty().NotNull().MinimumLength(USERNAME_MIN_LENGTH)
            .MaximumLength(USERNAME_MAX_LENGTH);
        RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(PASSWORD_MIN_LENGTH)
            .MaximumLength(PASSWORD_MAX_LENGTH)
            .Equal(x => x.ConfirmationPassword);
    }
}

public class CartItemModelValidator : AbstractValidator<CartItemModel>
{
    public CartItemModelValidator()
    {
        RuleFor(x => x.Quantity).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(x => x.ProductId).NotEmpty().NotNull().GreaterThan(0);
    }
}

public class CategoryModelValidator : AbstractValidator<CategoryModel>
{
    public CategoryModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}

public class ProductModelValidator : AbstractValidator<ProductModel>
{
    public ProductModelValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().NotNull();
        RuleFor(x => x.ProductDescription).NotEmpty().NotNull();
        RuleFor(x => x.Manufacturer).NotEmpty().NotNull();
        RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(x => x.Category).NotEmpty().NotNull();
        RuleFor(x => x.IconURL).NotEmpty().NotNull();
    }
}

