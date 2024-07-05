using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Schemas;

namespace TrackerService.Domain.UseCases;

public abstract class AbstractGoodsUseCases
{
    public abstract Task<string> Add(GoodsAddSchema goods, TrackerContext context);
    public abstract Task<ActionResult<GoodsInfoSchema>> GetById(int id, TrackerContext context);
    public abstract Task<ActionResult<IEnumerable<GoodsSchema>>> GetList(TrackerContext context);
}