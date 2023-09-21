using AutoMapper;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

using Microsoft.Extensions.Logging;

namespace Browl.Service.MarketDataCollector.Application.Services;

public class CustomerService : ICustomerManager
{
	private readonly ICustomerRepository _customerRepository;
	private readonly IMapper _mapper;
	private readonly ILogger<CustomerService> _logger;

	public CustomerService(ICustomerRepository customerRepository, IMapper mapper, ILogger<CustomerService> logger)
	{
		_customerRepository = customerRepository;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<IEnumerable<CustomerViewResource>> GetAsync()
	{
		var clientes = await _customerRepository.GetAsync();
		return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewResource>>(clientes);
	}

	public async Task<CustomerViewResource> GetAsync(int id)
	{
		var cliente = await _customerRepository.GetAsync(id);
		return _mapper.Map<CustomerViewResource>(cliente);
	}

	public async Task<CustomerResource> DeleteAsync(int id)
	{
		var cliente = await _customerRepository.DeleteAsync(id);
		return _mapper.Map<CustomerResource>(cliente);
	}

	public async Task<CustomerViewResource> PostAsync(CustomerResource novoCliente)
	{
		_logger.LogInformation("Chamada de negócio para inserir um cliente.");
		var cliente = _mapper.Map<Customer>(novoCliente);
		cliente = await _customerRepository.PostAsync(cliente);
		return _mapper.Map<CustomerViewResource>(cliente);
	}

	public async Task<CustomerViewResource> PutAsync(CustomerUpdateResource alteraCliente)
	{
		var cliente = _mapper.Map<Customer>(alteraCliente);
		cliente = await _customerRepository.PutAsync(cliente);
		return _mapper.Map<CustomerViewResource>(cliente);
	}
}
