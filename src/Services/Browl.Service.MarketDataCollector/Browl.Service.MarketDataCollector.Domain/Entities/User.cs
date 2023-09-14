namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class User
{
<<<<<<< HEAD
	public int Id { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string Login { get; set; }
	public string Password { get; set; }
	public ICollection<Role> Roles { get; set; }

	public User() => Roles = new HashSet<Role>();
=======
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Login { get; set; }
    public string Password { get; set; }
    public ICollection<Role> Roles { get; set; }

    public User() => Roles = new HashSet<Role>();
>>>>>>> dev
}