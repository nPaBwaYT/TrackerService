﻿using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
public class ProductController
{
    private readonly TrackerContext _context;
    private AbstractProductsUseCases _productUC;

    public ProductController(TrackerContext context)
    {
        _productUC = new ProductsUseCases();
        _context = context;
    }
    
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ProductSchema>>> GetList()
    {
        return await _productUC.GetList(_context);
    }
    
    [HttpPost()]
    public async Task<string> Add(ProductAddSchema product)
    {
        return await _productUC.Add(product, _context);
    }
    
    [HttpGet(nameof(GetInfo))]
    public async Task<ActionResult<ProductInfoSchema>> GetInfo(long id)
    {
        return await _productUC.GetById(id, _context);
    }
}