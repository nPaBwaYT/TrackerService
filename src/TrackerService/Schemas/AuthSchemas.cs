using System.ComponentModel.DataAnnotations;

namespace TrackerService.Schemas;

public class RegisterSchema
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { set; get; }
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { set; get; }
    
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password mismatch")]
    public string ConfirmPassword { set; get; }
}

public class LoginSchema
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { set; get; }
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { set; get; }
}