namespace TrackerService.Models;

public class Order
{
    public int Id { set; get; }
    public int ProductId { set; get; }
    public string Destination { set; get; }
    public string Status { set; get; }
    public bool IsCompleted { set; get; }
}