using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.Dto.Auth;
using Domain.Dto.Customer;
using Domain.Dto.User;
using Service.Abstract;
using Services.Abstract;
using Services.Abstract.Auth;

namespace Services.Implementation.Auth;

public class RegistrationService : IRegistrationService
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public RegistrationService(IUserService userService, ICustomerService customerService, IMapper mapper)
    {
        _userService = userService;
        _customerService = customerService;
        _mapper = mapper;
    }

    public async Task<UserDto> RegistrationAsync(RegistrationModel registration)
    {
        if (await IsNicknameFree(registration.UserName))
            throw new ValidationException($"Username: {registration.UserName} is occupied");


        var user = _mapper.Map<UserDto>(registration);
        await _userService.AddAsync(user);

        var userFromDb = await _userService.GetByUsername(registration.UserName);

        var customer = _mapper.Map<CustomerDto>(registration);
        customer.UserId = userFromDb.Id;

        await _customerService.AddAsync(customer);


        return user;
    }

    private async Task<bool> IsNicknameFree(string username)
    {
        var user = await _userService.GetByUsername(username);
        return user != null;
    }

    private bool PasswordsConfirmation(string password, string confirmationPassword)
    {
        return password == confirmationPassword;
    }
}