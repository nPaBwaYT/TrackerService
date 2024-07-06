using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Schemas;

namespace TrackerService.Domain.UseCases;

public abstract class AbstractProductsUseCases
{
    public abstract Task<string> Add(ProductAddSchema product, TrackerContext context);
    public abstract Task<ActionResult<ProductInfoSchema>> GetById(long id, TrackerContext context);
    public abstract Task<ActionResult<IEnumerable<ProductSchema>>> GetList(TrackerContext context);
}