using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class OrderController
{
    private readonly TrackerContext _context;
    private AbstractOrdersUseCases _orderUC;

    public OrderController(TrackerContext context)
    {
        _orderUC = new OrdersUseCases();
        _context = context;
    }
    
    /// <summary>
    /// Provides information about all the orders
    /// </summary>
    /// <returns></returns>
    [HttpGet(nameof(GetList))]
    public async Task<ActionResult<IEnumerable<OrderSchema>>> GetList()
    {
        return await _orderUC.GetList(_context);
    }
    
    /// <summary>
    /// Provides information about a specific order
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetInfo))]
    public async Task<ActionResult<OrderInfoSchema>> GetInfo(long id)
    {
        return await _orderUC.GetById(id, _context);
    }
    
    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(OrderAddSchema order)
    {
        return await _orderUC.Create(order, _context);
    }
    
    /// <summary>
    /// Updates status of a specific order (being processed => on the way => delivered)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch(nameof(UpdateStatus))]
    public async Task<IActionResult> UpdateStatus(long id)
    {
        return await _orderUC.UpdateStatus(id, _context);
    }
    
    /// <summary>
    /// Deletes a specific order
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete(nameof(Delete))]
    public async Task<IActionResult> Delete(long id)
    {
        return await _orderUC.Delete(id, _context);
    }
}