using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Resources.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.Controller;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUserManager manager;

    public UsuariosController(IUserManager manager)
    {
        this.manager = manager;
    }

    [HttpGet]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] User usuario)
    {
        var usuarioLogado = await manager.ValidaUsuarioEGeraTokenAsync(usuario);
        if (usuarioLogado != null)
        {
            return Ok(usuarioLogado);
        }
        return Unauthorized();
    }

    [Authorize(Roles = "Presidente, Lider")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        string login = User.Identity.Name;
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