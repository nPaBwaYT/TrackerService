using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrackerService.Dependencies;
using TrackerService.Models;

namespace TrackerService.Schemas;

public class OrderSchema
{
    public long Id { set; get; }
    public long ProductId { set; get; }
    public long UserId { set; get; }
    public string Destination { set; get; }
    public Status Status { set; get; }

    public OrderSchema(long id, long productId, long userId, string destination, short status)
    {
        Id = id;
        ProductId = productId;
        UserId = userId;
        Destination = destination;
        Status = (Status)status;
    }
}

public class OrderAddSchema
{
    [Required]
    public long ProductId { set; get; }

    [DefaultValue(0)]
    public long UserId { set; get; }

    [Required]
    public string Destination { set; get; }
    
    public OrderAddSchema(long productId, long userId, string destination)
    {
        ProductId = productId;
        UserId = userId;
        Destination = destination;
    }

    public Order ToModel()
    {
        Order order = new Order();
        order.ProductId = ProductId;
        order.UserId = UserId;
        order.Destination = Destination;
        order.Status = (short)Status.BeingProcessed;
        return order;
    }
}

public class OrderInfoSchema
{
    public long ProductId { set; get; }
    public long UserId { set; get; }
    public string Destination { set; get; }
    public Status Status { set; get; }
    
    public OrderInfoSchema(long productId, long userId, string destination, short status)
    {
        ProductId = productId;
        UserId = userId;
        Destination = destination;
        Status = (Status)status;
    }
}