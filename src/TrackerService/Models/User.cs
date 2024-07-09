using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerService.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    [Required]
    public string Email { set; get; }
    [Required] 
    public string Password { set; get; }
    
    [DefaultValue(false)]
    public bool IsAdmin { set; get; }
};
