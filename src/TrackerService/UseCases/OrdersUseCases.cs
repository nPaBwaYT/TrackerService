using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;

namespace TrackerService.UseCases;

public class OrdersUseCases: AbstractOrdersUseCases
{
    public override async Task<IActionResult> Create(OrderAddSchema order, TrackerContext context)
    {
        if (order.Destination.Split(' ')[0].Length == 0)
        {
            return new InvalidStringInputResponse();
        }
        context.Orders.Add(order.ToModel());
        await context.SaveChangesAsync();
        return new CreatedResult();
    }

    public override async Task<IActionResult> Delete(long id, TrackerContext context)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return new EntityDoesNotExistResponse();
        }
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public override async Task<IActionResult> UpdateStatus(long id, TrackerContext context)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return new EntityDoesNotExistResponse();
        }
        if (order.Status > 1)
        {
            return new OrderAlreadyCompletedResponse();
        }
        order.Status += 1;
        context.Entry(order).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public override async Task<ActionResult<OrderInfoSchema>> GetById(long id, TrackerContext context)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return new EntityDoesNotExistResponse();
        }
        return new OrderInfoSchema(order.ProductId, order.UserId, order.Destination, order.Status);
    }

    public override async Task<ActionResult<IEnumerable<OrderSchema>>> GetList(TrackerContext context)
    {
        List<OrderSchema> orders = new List<OrderSchema>();
        foreach (var order in await context.Orders.ToListAsync())
        {
            orders.Add(new OrderSchema(order.Id, order.ProductId, order.UserId, order.Destination, order.Status));
        }

        return orders;
    }
}