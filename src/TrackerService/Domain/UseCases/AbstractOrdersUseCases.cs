using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Schemas;

namespace TrackerService.Domain.UseCases;

public abstract class AbstractOrdersUseCases
{
    public abstract Task<IActionResult> Create(OrderAddSchema order, TrackerContext context);
    public abstract Task<IActionResult> Delete(long id, TrackerContext context);
    public abstract Task<IActionResult> UpdateStatus(long id, TrackerContext context);
    public abstract Task<ActionResult<OrderInfoSchema>> GetById(long id, TrackerContext context);
    public abstract Task<ActionResult<IEnumerable<OrderSchema>>> GetList(TrackerContext context);
}