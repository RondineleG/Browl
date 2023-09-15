using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
	private new readonly BrowlDbContext _browlDbContext;

	public CustomerRepository(BrowlDbContext context) : base(context) { }

	public async Task<IEnumerable<Customer>> GetAsync() => await _browlDbContext.Customers
			.Include(p => p.Endereco)
			.Include(p => p.Telefones)
			.AsNoTracking().ToListAsync();

	public async Task<Customer> GetAsync(int id) => await _browlDbContext.Customers
			.Include(p => p.Endereco)
			.Include(p => p.Telefones)
			.SingleOrDefaultAsync(p => p.Id == id);

	public async Task<Customer> PostAsync(Customer cliente)
	{
		_ = await _browlDbContext.Customers.AddAsync(cliente);
		_ = await _browlDbContext.SaveChangesAsync();
		return cliente;
	}

	public async Task<Customer> PutAsync(Customer cliente)
	{
		var clienteConsultado = await _browlDbContext.Customers
											 .Include(p => p.Endereco)
											 .Include(p => p.Telefones)
											 .FirstOrDefaultAsync(p => p.Id == cliente.Id);
		if (clienteConsultado == null)
		{
			return null;
		}
		_browlDbContext.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
		clienteConsultado.Endereco = cliente.Endereco;
		UpdateClienteTelefones(cliente, clienteConsultado);
		_ = await _browlDbContext.SaveChangesAsync();
		return clienteConsultado;
	}

	private static void UpdateClienteTelefones(Customer cliente, Customer clienteConsultado)
	{
		clienteConsultado.Telefones.Clear();
		foreach (var telefone in cliente.Telefones)
		{
			clienteConsultado.Telefones.Add(telefone);
		}
	}

	public async Task<Customer> DeleteAsync(int id)
	{
		var clienteConsultado = await _browlDbContext.Customers.FindAsync(id);
		if (clienteConsultado == null)
		{
			return null;
		}
		var clienteRemovido = _browlDbContext.Customers.Remove(clienteConsultado);
		_ = await _browlDbContext.SaveChangesAsync();
		return clienteRemovido.Entity;
	}
}
