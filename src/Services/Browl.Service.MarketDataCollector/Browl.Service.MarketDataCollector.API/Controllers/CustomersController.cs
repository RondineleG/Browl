using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
<<<<<<< HEAD

using Microsoft.AspNetCore.Mvc;

using SerilogTimings;

namespace Browl.Service.MarketDataCollector.API.Controllers;
=======
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace Browl.Service.MarketDataCollector.Controller;
>>>>>>> dev

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
<<<<<<< HEAD
	private readonly ICustomerManager clienteManager;
	private readonly ILogger<CustomersController> logger;

	public CustomersController(ICustomerManager clienteManager, ILogger<CustomersController> logger)
	{
		this.clienteManager = clienteManager;
		this.logger = logger;
	}

	/// <summary>
	/// Lists all customers.
	/// </summary>
	/// <returns>List os customers.</returns>
	[HttpGet]
	[ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get()
	{
		var clientes = await clienteManager.GetAsync();
		return clientes.Any() ? Ok(clientes) : NotFound();
	}

	/// <summary>
	/// Return customer searching by id.
	/// </summary>
	/// <param name="id" example="123">Id</param>
	[HttpGet("{id}")]
	[ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get(int id)
	{
		var cliente = await clienteManager.GetAsync(id);
		return cliente.Id == 0 ? NotFound() : Ok(cliente);
	}

	/// <summary>
	/// Create new customer
	/// </summary>
	/// <param name="customerResource"></param>
	[HttpPost]
	[ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Post(CustomerResource customerResource)
	{
		logger.LogInformation("Objeto recebido {@novoCliente}", customerResource);

		CustomerViewResource clienteInserido;
		using (Operation.Time("Tempo de adição de um novo cliente."))
		{
			logger.LogInformation("Foi requisitada a inserção de um novo cliente.");
			clienteInserido = await clienteManager.PostAsync(customerResource);
		}
		return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
	}

	/// <summary>
	/// Update customer.
	/// </summary>
	/// <param name="customerUpdateResource"></param>
	[HttpPut]
	[ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Put(CustomerUpdateResource customerUpdateResource)
	{
		var clienteAtualizado = await clienteManager.PutAsync(customerUpdateResource);
		return clienteAtualizado == null ? NotFound() : Ok(clienteAtualizado);
	}

	/// <summary>
	/// Delete customer.
	/// </summary>
	/// <param name="id" example="123">Id</param>
	/// <remarks>When deleting a customer, it will be permanently removed from the base.</remarks>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Delete(int id)
	{
		var clienteExcliudo = await clienteManager.DeleteAsync(id);
		return clienteExcliudo == null ? NotFound() : NoContent();
	}
=======
    private readonly ICustomerManager clienteManager;
    private readonly ILogger<CustomersController> logger;

    public CustomersController(ICustomerManager clienteManager, ILogger<CustomersController> logger)
    {
        this.clienteManager = clienteManager;
        this.logger = logger;
    }

    /// <summary>
    /// Lists all customers.
    /// </summary>
    /// <returns>List os customers.</returns>
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
    /// Return customer searching by id.
    /// </summary>
    /// <param name="id" example="123">Id</param>
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
    /// Create new customer
    /// </summary>
    /// <param name="customerResource"></param>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(CustomerResource customerResource)
    {
        logger.LogInformation("Objeto recebido {@novoCliente}", customerResource);

        CustomerViewResource clienteInserido;
        using (Operation.Time("Tempo de adição de um novo cliente."))
        {
            logger.LogInformation("Foi requisitada a inserção de um novo cliente.");
            clienteInserido = await clienteManager.PostAsync(customerResource);
        }
        return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
    }

    /// <summary>
    /// Update customer.
    /// </summary>
    /// <param name="customerUpdateResource"></param>
    [HttpPut]
    [ProducesResponseType(typeof(CustomerViewResource), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(CustomerUpdateResource customerUpdateResource)
    {
        var clienteAtualizado = await clienteManager.PutAsync(customerUpdateResource);
        if (clienteAtualizado == null)
        {
            return NotFound();
        }
        return Ok(clienteAtualizado);
    }

    /// <summary>
    /// Delete customer.
    /// </summary>
    /// <param name="id" example="123">Id</param>
    /// <remarks>When deleting a customer, it will be permanently removed from the base.</remarks>
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
>>>>>>> dev
}