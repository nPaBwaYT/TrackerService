using TrackerService.Schemas;

namespace TrackerService.Domain.UseCases;

public abstract class AbstractGoodsUseCases
{
    public abstract void Add(GoodsAddSchema goods);
    public abstract GoodsInfoSchema GetById(int id);
    public abstract List<GoodsSchema> GetList();
}