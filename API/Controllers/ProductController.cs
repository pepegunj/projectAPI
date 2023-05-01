using API.Controllers.Base;
using API.Models;
using AutoMapper;
using Domain.Dto.Pagination;
using Domain.Dto.Product;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace API.Controllers;

[ApiController]
public class ProductController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;
    private readonly IValidator<ProductModel> _validator;

    public ProductController(IProductService product, IMapper mapper, IValidator<ProductModel> validator)
    {
        _productService = product;
        _mapper = mapper;
        _validator = validator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("/product")]
    public async Task AddProduct([FromBody] ProductModel model)
    {
        await _validator.ValidateAndThrowAsync(model);
        var result = _mapper.Map<ProductDto>(model);
        await _productService.AddAsync(result);
    }

    [HttpGet("/product")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
    {
        var result = await _productService.GetAllAsync();


        return Ok(_mapper.Map<IEnumerable<ProductModel>>(result));
    }

    [HttpGet("/product/{id}")]
    public async Task<ActionResult<IEnumerable<ProductModel>>> GetById(int id)
    {
        var result = await _productService.GetByIdAsync(id);


        return Ok(_mapper.Map<ProductModel>(result));
    }

    [HttpGet("/product/manufacturers")]
    [AllowAnonymous]
    public async Task<IEnumerable<string>> GetAllManufacturers()
    {
        return await _productService.GetAllManufacturersAsync();
    }

    [HttpPost("paginated-search")]
    [AllowAnonymous]
    public async Task<PaginatedResult<ProductModel>> GetPagedProductsAsync([FromBody] PagedRequest pagedRequest,
        CancellationToken cancellationToken)
    {
        var response = await _productService.GetPageWithIncludeAsync(pagedRequest, cancellationToken);

        return new PaginatedResult<ProductModel>
        {
            PageIndex = response.PageIndex,
            PageSize = response.PageSize,
            Total = response.Total,
            Items = response.Items.Select(e => _mapper.Map<ProductModel>(e)).ToList()
        };
    }
}