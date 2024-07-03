using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
public class GoodsController
{
    private AbstractGoodsUseCases GoodsUC = new GoodsUseCases();
    
    [HttpGet()]
    public List<GoodsSchema> GetList()
    {
        return GoodsUC.GetList();
    }
    
    [HttpPost()]
    public void Add(GoodsAddSchema goods)
    {
        GoodsUC.Add(goods);
    }
    
    [HttpGet(nameof(GetInfo))]
    public GoodsInfoSchema GetInfo(int id)
    {
        return GoodsUC.GetById(id);
    }
}