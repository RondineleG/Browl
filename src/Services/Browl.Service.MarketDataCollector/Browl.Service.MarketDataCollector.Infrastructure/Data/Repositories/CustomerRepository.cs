using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public CustomerRepository(BrowlDbContext context) : base(context) { }

    public async Task<IEnumerable<Customer>> GetClientesAsync()
    {
        return await _browlDbContext.Customers
            .Include(p => p.Endereco)
            .Include(p => p.Telefones)
            .AsNoTracking().ToListAsync();
    }

    public async Task<Customer> GetClienteAsync(int id)
    {
        return await _browlDbContext.Customers
            .Include(p => p.Endereco)
            .Include(p => p.Telefones)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Customer> InsertClienteAsync(Customer cliente)
    {
        await _browlDbContext.Customers.AddAsync(cliente);
        await _browlDbContext.SaveChangesAsync();
        return cliente;
    }

    public async Task<Customer> UpdateClienteAsync(Customer cliente)
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
        await _browlDbContext.SaveChangesAsync();
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

    public async Task<Customer> DeleteClienteAsync(int id)
    {
        var clienteConsultado = await _browlDbContext.Customers.FindAsync(id);
        if (clienteConsultado == null)
        {
            return null;
        }
        var clienteRemovido = _browlDbContext.Customers.Remove(clienteConsultado);
        await _browlDbContext.SaveChangesAsync();
        return clienteRemovido.Entity;
    }
}