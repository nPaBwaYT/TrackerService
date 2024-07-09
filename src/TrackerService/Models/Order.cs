using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerService.Dependencies;

namespace TrackerService.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    
    [Required]
    [ForeignKey("Product.Id")]
    public long ProductId { set; get; }
    
    [Required]
    [ForeignKey("User.Id")]
    public long UserId { set; get; }
    
    [Required]
    public string Destination { set; get; }
    
    [Required]
    public short Status { set; get; }
}