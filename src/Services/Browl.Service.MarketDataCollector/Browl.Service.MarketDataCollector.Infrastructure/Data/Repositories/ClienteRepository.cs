using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class ClienteRepository : BaseRepository, IClienteRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public ClienteRepository(BrowlDbContext context) : base(context) { }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await _browlDbContext.Clientes
            .Include(p => p.Endereco)
            .Include(p => p.Telefones)
            .AsNoTracking().ToListAsync();
    }

    public async Task<Cliente> GetClienteAsync(int id)
    {
        return await _browlDbContext.Clientes
            .Include(p => p.Endereco)
            .Include(p => p.Telefones)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Cliente> InsertClienteAsync(Cliente cliente)
    {
        await _browlDbContext.Clientes.AddAsync(cliente);
        await _browlDbContext.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
    {
        var clienteConsultado = await _browlDbContext.Clientes
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

    private static void UpdateClienteTelefones(Cliente cliente, Cliente clienteConsultado)
    {
        clienteConsultado.Telefones.Clear();
        foreach (var telefone in cliente.Telefones)
        {
            clienteConsultado.Telefones.Add(telefone);
        }
    }

    public async Task<Cliente> DeleteClienteAsync(int id)
    {
        var clienteConsultado = await _browlDbContext.Clientes.FindAsync(id);
        if (clienteConsultado == null)
        {
            return null;
        }
        var clienteRemovido = _browlDbContext.Clientes.Remove(clienteConsultado);
        await _browlDbContext.SaveChangesAsync();
        return clienteRemovido.Entity;
    }
}