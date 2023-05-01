using API.Controllers.Base;
using API.Models;
using AutoMapper;
using Domain.Dto.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract.Auth;

namespace API.Controllers.Auth;

[Route("registration")]
public class RegistrationController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IRegistrationService _registrationService;
    private readonly IValidator<RegistrationModel> _validator;

    public RegistrationController(IRegistrationService registrationService, IMapper mapper,
        IValidator<RegistrationModel> validator)
    {
        _registrationService = registrationService;
        _mapper = mapper;
        _validator = validator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<UserModel> RegistrationAsync([FromBody] RegistrationModel registrationModel)
    {
        await _validator.ValidateAndThrowAsync(registrationModel);
        var user = await _registrationService.RegistrationAsync(registrationModel);
        return _mapper.Map<UserModel>(user);
    }
}