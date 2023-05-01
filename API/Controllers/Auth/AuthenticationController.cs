using API.Controllers.Base;
using Domain.Dto.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract.Auth;

namespace API.Controllers.Auth;

[Route("login")]
public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ITokenService _tokenService;
    private readonly IValidator<AuthRequest> _validator;

    public AuthenticationController(IAuthenticationService authenticationService, ITokenService tokenService,
        IValidator<AuthRequest> validator)
    {
        _authenticationService = authenticationService;
        _tokenService = tokenService;
        _validator = validator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<AuthResponse>> LoginAsync([FromBody] AuthRequest request)
    {
        await _validator.ValidateAndThrowAsync(request);
        var user = await _authenticationService.AuthenticateAsync(request);
        if (user != null)
        {
            user.Token = _tokenService.GetAccessToken(user);
            return Ok(user);
        }

        return NotFound();
    }
}