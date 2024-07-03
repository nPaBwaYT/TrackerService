using Microsoft.AspNetCore.Http.HttpResults;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;

namespace TrackerService.UseCases;

public class GoodsUseCases:AbstractGoodsUseCases
{
    public override void Add(GoodsAddSchema goods)
    {
        /*UOW Uow = await OpenSession();
        await AddGoods(AbstractUOW Uow, GoodsAddSchema goods);
        await Uow.CloseSession();*/
    }

    public override GoodsInfoSchema GetById(int id)
    {
        return new GoodsInfoSchema("name");
    }

    public override List<GoodsSchema> GetList()
    {
        return [];
    }
}