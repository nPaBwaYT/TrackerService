using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Models;
using TrackerService.Schemas;

namespace TrackerService.UseCases;

public class GoodsUseCases:AbstractGoodsUseCases
{
    
    public override async Task<string> Add(GoodsAddSchema product, TrackerContext context)
    {
        context.Products.Add(product.conv());
        return "status: OK";
    }

    public override async Task<ActionResult<GoodsInfoSchema>> GetById(int id, TrackerContext context)
    {
        var product = await context.Products.FindAsync(id);
        return new GoodsInfoSchema(product.Name);
    }

    public override async Task<ActionResult<IEnumerable<GoodsSchema>>> GetList(TrackerContext context)
    {
        List<GoodsSchema> products = new List<GoodsSchema>();
        foreach (var product in await context.Products.ToListAsync())
        {
            products.Add(new GoodsSchema(product.Id, product.Name));
        }

        return products;
    }
}