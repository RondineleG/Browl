using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Resources.User;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IUserManager manager;

	public UsersController(IUserManager manager) => this.manager = manager;

	[HttpGet]
	[Route("Login")]
	public async Task<IActionResult> Login([FromBody] User usuario)
	{
		var usuarioLogado = await manager.ValidaUsuarioEGeraTokenAsync(usuario);
		return usuarioLogado != null ? Ok(usuarioLogado) : Unauthorized();
	}


	/// <summary>
	/// Lists all users.
	/// </summary>
	/// <returns>List os users.</returns>
	[Authorize(Roles = "Presidente, Lider")]
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var login = User.Identity.Name;
		var usuario = await manager.GetAsync(login);
		return Ok(usuario);
	}

	[HttpPost]
	public async Task<IActionResult> Post(UserNewResource usuario)
	{
		var usuarioInserido = await manager.InsertAsync(usuario);
		return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
	}
}