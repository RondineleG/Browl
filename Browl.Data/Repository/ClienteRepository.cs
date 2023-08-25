using Browl.Core.Entities;
using Browl.Core.Interfaces.Repositories;
using Browl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Browl.Data.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public ClienteRepository(BrowlDbContext browlDbContext)
    {
        _browlDbContext = browlDbContext;
    }

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