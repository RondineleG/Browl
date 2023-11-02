using System.Collections.Generic;
using System.Linq;
using Browl.MVC.Models;				// Utilizando a pasta Models

namespace Browl.MVC.Repositories;

public static class UserRepository
{
	public static User Get(string email, string passwordHash)
	{
		var users = new List<User>();
		users.Add(new User { Id = 1, Email = "batman", Nome = "batman", PasswordHash = "manager" });
		users.Add(new User { Id = 2, Email = "robin", Nome = "robin", PasswordHash = "employee" });
		return users.Where(x => x.Email.ToLower() == email.ToLower() && x.PasswordHash == x.PasswordHash).FirstOrDefault();
	}
}
