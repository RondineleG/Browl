using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using Microsoft.Extensions.Logging;

namespace Browl.Service.MarketDataCollector.Application.Implementation;

public class CustomerManager : ICustomerManager
{
    private readonly ICustomerRepository clienteRepository;
    private readonly IMapper mapper;
    private readonly ILogger<CustomerManager> logger;

    public CustomerManager()
    {

    }
    public CustomerManager(ICustomerRepository clienteRepository, IMapper mapper, ILogger<CustomerManager> logger)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<IEnumerable<CustomerView>> GetClientesAsync()
    {
        var clientes = await clienteRepository.GetClientesAsync();
        return mapper.Map<IEnumerable<Domain.Entities.Customer>, IEnumerable<CustomerView>>(clientes);
    }

    public async Task<CustomerView> GetClienteAsync(int id)
    {
        var cliente = await clienteRepository.GetClienteAsync(id);
        return mapper.Map<CustomerView>(cliente);
    }

    public async Task<CustomerView> DeleteClienteAsync(int id)
    {
        var cliente = await clienteRepository.DeleteClienteAsync(id);
        return mapper.Map<CustomerView>(cliente);
    }

    public async Task<CustomerView> InsertClienteAsync(CustomerResource novoCliente)
    {
        logger.LogInformation("Chamada de negócio para inserir um cliente.");
        var cliente = mapper.Map<Domain.Entities.Customer>(novoCliente);
        cliente = await clienteRepository.InsertClienteAsync(cliente);
        return mapper.Map<CustomerView>(cliente);
    }

    public async Task<CustomerView> UpdateClienteAsync(CustomerUpdateResource alteraCliente)
    {
        var cliente = mapper.Map<Domain.Entities.Customer>(alteraCliente);
        cliente = await clienteRepository.UpdateClienteAsync(cliente);
        return mapper.Map<CustomerView>(cliente);
    }
}