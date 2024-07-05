using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
public class GoodsController
{
    private readonly TrackerContext _context;

    public GoodsController(TrackerContext context)
    {
        _context = context;
    }
    
    private AbstractGoodsUseCases GoodsUC = new GoodsUseCases();
    
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<GoodsSchema>>> GetList()
    {
        return await GoodsUC.GetList(_context);
    }
    
    [HttpPost()]
    public async Task<string> Add(GoodsAddSchema goods)
    {
        return await GoodsUC.Add(goods, _context);
    }
    
    [HttpGet(nameof(GetInfo))]
    public async Task<ActionResult<GoodsInfoSchema>> GetInfo(int id)
    {
        return await GoodsUC.GetById(id, _context);
    }
}