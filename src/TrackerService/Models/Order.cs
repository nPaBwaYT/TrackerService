using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerService.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    public long ProductId { set; get; }
    public string Destination { set; get; }
    public string Status { set; get; } //переделать в enum
    public bool IsCompleted { set; get; }
}