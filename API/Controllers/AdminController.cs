using API.Controllers.Base;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public AdminController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPatch]
    [Route("/admin/add")]

    public async Task<bool> AddAdmin([FromForm] int id)
    {
        return await _userService.AddAdminByIdAsync(id);
    }
}