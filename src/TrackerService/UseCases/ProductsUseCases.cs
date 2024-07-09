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
    
    public override async Task<IActionResult> Add(ProductAddSchema product, TrackerContext context)
    {
        if (product.Name.Split(' ')[0].Length == 0)
        {
            return new InvalidStringInputResponse();
        }
        context.Products.Add(product.ToModel());
        await context.SaveChangesAsync();
        return new CreatedResult();
    }

    public override async Task<ActionResult<ProductInfoSchema>> GetById(long id, TrackerContext context)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return new EntityDoesNotExistResponse();
        }
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

    public override async Task<IActionResult> Delete(long id, TrackerContext context)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return new EntityDoesNotExistResponse();
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return new OkResult();
    }
}