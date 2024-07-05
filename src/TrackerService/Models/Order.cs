using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerService.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { set; get; }
    public int ProductId { set; get; }
    public string Destination { set; get; }
    public string Status { set; get; }
    public bool IsCompleted { set; get; }
}