using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Models;
using TrackerService.Schemas;

namespace TrackerService.UseCases;

public class ProductsUseCases:AbstractProductsUseCases
{
    
    public override async Task<string> Add(ProductAddSchema product, TrackerContext context)
    {
        context.Products.Add(product.conv());
        return "status: OK";
    }

    public override async Task<ActionResult<ProductInfoSchema>> GetById(long id, TrackerContext context)
    {
        var product = await context.Products.FindAsync(id);
        return new ProductInfoSchema(product.Name);
    }

    public override async Task<ActionResult<IEnumerable<ProductSchema>>> GetList(TrackerContext context)
    {
        List<ProductSchema> products = new List<ProductSchema>();
        foreach (var product in await context.Products.ToListAsync())
        {
            products.Add(new ProductSchema(product.Id, product.Name));
        }

        return products;
    }
}