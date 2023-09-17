using System;
using System.Text;

using Browl.Service.AuthSecurity.API.Entities;

namespace Browl.Service.AuthSecurity.API.Test.Builder;

public static class RandomUserGenerator
{
	private static readonly Random Random = new Random();

	public static UserRegister GenerateRandomUser()
	{
		var userName = GenerateRandomString(8);
		var firstName = GenerateRandomString(6);
		var lastName = GenerateRandomString(6);
		var userNameChangeLimit = Random.Next(0, 10);
		var profilePicture = GenerateRandomBytes(64); // Tamanho do perfil da imagem em bytes
		var email = GenerateRandomEmail();
		var password = GenerateRandomString(10);
		var passwordConfirmation = password;

		return new UserRegister(userName, firstName, lastName, userNameChangeLimit, profilePicture, email, password, passwordConfirmation);
	}

	private static string GenerateRandomString(int length)
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[Random.Next(s.Length)])
			.ToArray());
	}

	private static byte[] GenerateRandomBytes(int length)
	{
		var buffer = new byte[length];
		Random.NextBytes(buffer);
		return buffer;
	}

	private static string GenerateRandomEmail()
	{
		string[] domains = { "example.com", "test.org", "sample.net" };
		var userName = GenerateRandomString(8);
		var domain = domains[Random.Next(domains.Length)];
		return $"{userName}@{domain}";
	}
}
