using System.ComponentModel.DataAnnotations;

namespace Browl.Service.AuthSecurity.Domain.Models;

public class InputModel
{
    [Required]
    [Display(Name = "Email / Username")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}