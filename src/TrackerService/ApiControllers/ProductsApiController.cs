using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductController
{
    private readonly TrackerContext _context;
    private AbstractProductsUseCases _productUC;

    public ProductController(TrackerContext context)
    {
        _productUC = new ProductsUseCases();
        _context = context;
    }
    
    /// <summary>
    /// Provides information about all the products
    /// </summary>
    /// <returns></returns>
    [HttpGet(nameof(GetList))]
    public async Task<ActionResult<IEnumerable<ProductSchema>>> GetList()
    {
        return await _productUC.GetList(_context);
    }
    
    /// <summary>
    /// Provides information about a specific product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetInfo))]
    public async Task<ActionResult<ProductInfoSchema>> GetInfo(long id)
    {
        return await _productUC.GetById(id, _context);
    }
    
    /// <summary>
    /// Adds new product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add(ProductAddSchema product)
    {
        return await _productUC.Add(product, _context);
    }

    /// <summary>
    /// Deletes a specific product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete(nameof(Delete))]
    public async Task<IActionResult> Delete(long id)
    {
        return await _productUC.Delete(id, _context);
    }
}