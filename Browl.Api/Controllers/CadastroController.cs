using System.Collections.Generic;
using System.Data.SqlClient;
using Browl.MVC.Models;
using FluentAssertions.Equivalency;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Browl.MVC.Controllers;
public class CadastroController : Controller
{
	private readonly SqlConnection _sqlConnection;

	public CadastroController(SqlConnection sqlConnection)
	{
		_sqlConnection = sqlConnection;
	}
	[HttpPost]
	public ActionResult Cadastro(string email, string nome, string password)
	{	
			// Validando se os campos estão preenchidos
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(password))
			{
				TempData["CadastroAuthenticateError"] = "Todos os campos devem ser preenchidos";
				return RedirectToAction("cadastro", "Login");
			}

			// Verifica se o e-mail já esta cadastrado
			using (var checkEmailComand = new SqlCommand("SELECT COUNT(*) FROM User WHERE Email = @Email", _sqlConnection))
			{
				checkEmailComand.Parameters.AddWithValue("@Email", email);
				_sqlConnection.Open();
				int emailCount = (int)checkEmailComand.ExecuteScalar();

				if (emailCount > 0)
				{
					TempData["CadastroAuthenticateError"] = "Este e-mail ja foi cadastrado";
					return RedirectToAction("cadastro", "Login");
				}
			}

			// Criando novo usuário
			using (var insertUserCommand = new SqlCommand("INSERT INTO User(Email, Nome, PasswordHash) VALUES(@Email, @Nome, @PasswordHash)", _sqlConnection))
			{
				insertUserCommand.Parameters.AddWithValue("@Email", email);
				insertUserCommand.Parameters.AddWithValue("@Nome", nome);
				insertUserCommand.Parameters.AddWithValue("@PasswordHash", password);

				insertUserCommand.ExecuteNonQuery();
			}

			TempData["CadastroSucesso"] = "Usuário cadastrado com sucesso!";

			return RedirectToAction("Index", "Home"); // Redireciona para página Inicial
		
	}
}
