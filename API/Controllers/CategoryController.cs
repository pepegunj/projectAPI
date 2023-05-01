using API.Controllers.Base;
using API.Models;
using AutoMapper;
using Domain.Dto.Category;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace API.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly IValidator<CategoryModel> _validator;

    public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<CategoryModel> validator)
    {
        _validator = validator;
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<CategoryModel>>> GetAllCategories()
    {
        var result = await _categoryService.GetAllAsync();


        return Ok(_mapper.Map<IEnumerable<CategoryModel>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task AddCategory([FromBody] CategoryModel model)
    {
        await _validator.ValidateAndThrowAsync(model);
        var result = _mapper.Map<CategoryDto>(model);
        await _categoryService.AddAsync(result);
    }
}