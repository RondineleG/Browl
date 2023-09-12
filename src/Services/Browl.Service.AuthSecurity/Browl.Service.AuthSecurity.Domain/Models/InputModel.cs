using System.ComponentModel.DataAnnotations;

namespace Browl.Service.AuthSecurity.Domain.Models;

public class InputModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public byte[] ProfilePicture { get; set; }
}