using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace Browl.Service.MarketDataCollector.Controller;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ICustomerManager clienteManager;
    private readonly ILogger<ClientesController> logger;

    public ClientesController(ICustomerManager clienteManager, ILogger<ClientesController> logger)
    {
        this.clienteManager = clienteManager;
        this.logger = logger;
    }

    /// <summary>
    /// Retorna todos clientes cadastrados na base.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var clientes = await clienteManager.GetAsync();
        if (clientes.Any())
        {
            return Ok(clientes);
        }
        return NotFound();
    }

    /// <summary>
    /// Retorna um cliente consultado pelo id.
    /// </summary>
    /// <param name="id" example="123">Id do cliente.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(int id)
    {
        var cliente = await clienteManager.GetAsync(id);
        if (cliente.Id == 0)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    /// <summary>
    /// Insere um novo cliente
    /// </summary>
    /// <param name="novoCliente"></param>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(CustomerResource novoCliente)
    {
        logger.LogInformation("Objeto recebido {@novoCliente}", novoCliente);

        CustomerViewResource clienteInserido;
        using (Operation.Time("Tempo de adição de um novo cliente."))
        {
            logger.LogInformation("Foi requisitada a inserção de um novo cliente.");
            clienteInserido = await clienteManager.PostAsync(novoCliente);
        }
        return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
    }

    /// <summary>
    /// Altera um cliente.
    /// </summary>
    /// <param name="alteraCliente"></param>
    [HttpPut]
    [ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(CustomerUpdateResource alteraCliente)
    {
        var clienteAtualizado = await clienteManager.PutAsync(alteraCliente);
        if (clienteAtualizado == null)
        {
            return NotFound();
        }
        return Ok(clienteAtualizado);
    }

    /// <summary>
    /// Exclui um cliente.
    /// </summary>
    /// <param name="id" example="123">Id do cliente</param>
    /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base.</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        var clienteExcliudo = await clienteManager.DeleteAsync(id);
        if (clienteExcliudo == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}