using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation.Auth;

namespace API.Controllers.Base;

[ApiController]
[Authorize]
public abstract class BaseController : Controller
{
    [NonAction]
    protected int GetUserId()
    {
        return Convert.ToInt32(HttpContext.User.FindFirst(TokenClaims.ID).Value);
    }
}