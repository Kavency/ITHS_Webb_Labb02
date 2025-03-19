using KayakCove.Application.DTOs;
using KayakCove.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayakCove.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public ProductsController(ProductService productService, CategoryService categoryService)
    {
        this._productService = productService;
        this._categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var productDtos = await _productService.GetAllProductsAsync();
        return Ok(productDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var productDto = await _productService.GetProductByIdAsync(id);
        return productDto == null ? NotFound() : Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        await _productService.CreateProductAsync(productDto);
        return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
    {
        if (id != productDto.Id) return BadRequest();
        await _productService.UpdateProductAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}
