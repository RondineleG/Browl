using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Dtos.Cliente;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Browl.Service.MarketDataCollector.Application.Implementation;

public class ClienteManager : IClienteManager
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;
    private readonly ILogger<ClienteManager> logger;

    public ClienteManager()
    {
            
    }
    public ClienteManager(IClienteRepository clienteRepository, IMapper mapper, ILogger<ClienteManager> logger)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<IEnumerable<ClienteView>> GetClientesAsync()
    {
        var clientes = await clienteRepository.GetClientesAsync();
        return mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(clientes);
    }

    public async Task<ClienteView> GetClienteAsync(int id)
    {
        var cliente = await clienteRepository.GetClienteAsync(id);
        return mapper.Map<ClienteView>(cliente);
    }

    public async Task<ClienteView> DeleteClienteAsync(int id)
    {
        var cliente = await clienteRepository.DeleteClienteAsync(id);
        return mapper.Map<ClienteView>(cliente);
    }

    public async Task<ClienteView> InsertClienteAsync(NovoCliente novoCliente)
    {
        logger.LogInformation("Chamada de negócio para inserir um cliente.");
        var cliente = mapper.Map<Cliente>(novoCliente);
        cliente = await clienteRepository.InsertClienteAsync(cliente);
        return mapper.Map<ClienteView>(cliente);
    }

    public async Task<ClienteView> UpdateClienteAsync(AlteraCliente alteraCliente)
    {
        var cliente = mapper.Map<Cliente>(alteraCliente);
        cliente = await clienteRepository.UpdateClienteAsync(cliente);
        return mapper.Map<ClienteView>(cliente);
    }
}