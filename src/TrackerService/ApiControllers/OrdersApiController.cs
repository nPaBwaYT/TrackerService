using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
public class OrderController
{
    private readonly TrackerContext _context;
    private AbstractOrdersUseCases _orderUC;

    public OrderController(TrackerContext context)
    {
        _orderUC = new OrdersUseCases();
        _context = context;
    }
    
    [HttpGet(nameof(GetList))]
    public async Task<ActionResult<IEnumerable<OrderSchema>>> GetList()
    {
        return await _orderUC.GetList(_context);
    }
    
    [HttpGet(nameof(GetInfo))]
    public async Task<ActionResult<OrderInfoSchema>> GetInfo(long id)
    {
        return await _orderUC.GetById(id, _context);
    }
    
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(OrderAddSchema order)
    {
        return await _orderUC.Create(order, _context);
    }
    
    [HttpPatch(nameof(UpdateStatus))]
    public async Task<IActionResult> UpdateStatus(long id)
    {
        return await _orderUC.UpdateStatus(id, _context);
    }
    
    [HttpDelete(nameof(Delete))]
    public async Task<IActionResult> Delete(long id)
    {
        return await _orderUC.Delete(id, _context);
    }
}