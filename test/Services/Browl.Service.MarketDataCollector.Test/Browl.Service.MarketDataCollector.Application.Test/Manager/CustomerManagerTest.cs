using AutoMapper;

using Browl.Service.MarketDataCollector.Application.Mappings;
using Browl.Service.MarketDataCollector.Application.Services;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using Browl.Service.MarketDataCollector.FakeData.CustomerData;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Browl.Service.MarketDataCollector.Application.Test.Manager;

public class CustomerManagerTest
{
	private readonly ICustomerRepository repository;
	private readonly ILogger<CustomerService> logger;
	private readonly IMapper mapper;
	private readonly ICustomerService manager;
	private readonly Customer Customer;
	private readonly Customer NovoCustomer;
	private readonly Customer AlteraCustomer;
	private readonly CustomerFaker CustomerFaker;
	private readonly CustomerNewFaker NovoCustomerFaker;
	private readonly CustomerUpdateFaker AlteraCustomerFaker;

	public CustomerManagerTest()
	{
		repository = Substitute.For<ICustomerRepository>();
		logger = Substitute.For<ILogger<CustomerService>>();
		mapper = new MapperConfiguration(p => p.AddProfile<CustomerNewProfile>()).CreateMapper();
		manager = new CustomerService(repository, mapper, logger);
		CustomerFaker = new CustomerFaker();
		NovoCustomerFaker = new CustomerNewFaker();
		AlteraCustomerFaker = new CustomerUpdateFaker();

		Customer = CustomerFaker.Generate();
		NovoCustomer = NovoCustomerFaker.Generate()!;
		AlteraCustomer = AlteraCustomerFaker.Generate()!;
	}

	[Fact]
	public async Task GetCustomersAsync_Sucesso()
	{
		var listaCustomers = CustomerFaker.Generate(10);
		_ = repository.GetAsync().Returns(listaCustomers);
		var controle = mapper.Map<IEnumerable<Customer>, IEnumerable<Customer>>(listaCustomers);
		var retorno = await manager.GetAsync();

		_ = await repository.Received().GetAsync();
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task GetCustomersAsync_Vazio()
	{
		_ = repository.GetAsync().Returns(new List<Customer>());

		var retorno = await manager.GetAsync();

		_ = await repository.Received().GetAsync();
		_ = retorno.Should().BeEquivalentTo(new List<Customer>());
	}

	[Fact]
	public async Task GetAsync_Sucesso()
	{
		_ = repository.GetAsync(Arg.Any<int>()).Returns(Customer);
		var controle = mapper.Map<Customer>(Customer);
		var retorno = await manager.GetAsync(Customer.Id);

		_ = await repository.Received().GetAsync(Arg.Any<int>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task GetAsync_NaoEncontrado()
	{
		_ = repository.GetAsync(Arg.Any<int>()).Returns(new Customer());
		var controle = mapper.Map<Customer>(new Customer());
		var retorno = await manager.GetAsync(1);

		_ = await repository.Received().GetAsync(Arg.Any<int>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task PostAsync_Sucesso()
	{
		_ = repository.PostAsync(Arg.Any<Customer>()).Returns(Customer);
		var controle = mapper.Map<Customer>(Customer);

		var novoCustomerResource = mapper.Map<CustomerResource>(NovoCustomer);

		var retorno = await manager.PostAsync(novoCustomerResource);

		_ = await repository.Received().PostAsync(Arg.Any<Customer>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task PutAsync_Sucesso()
	{
		_ = repository.PutAsync(Arg.Any<Customer>()).Returns(Customer);
		var controle = mapper.Map<Customer>(Customer);
		var novoCustomerResource = mapper.Map<CustomerUpdateResource>(AlteraCustomer);

		var retorno = await manager.PutAsync(novoCustomerResource);

		_ = await repository.Received().PutAsync(Arg.Any<Customer>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task PutAsync_NaoEncontrado()
	{
		_ = repository.PutAsync(Arg.Any<Customer>()).ReturnsNull();

		var novoCustomerResource = mapper.Map<CustomerUpdateResource>(AlteraCustomer);

		var retorno = await manager.PutAsync(novoCustomerResource);

		_ = await repository.Received().PutAsync(Arg.Any<Customer>());
		_ = retorno.Should().BeNull();
	}

	[Fact]
	public async Task DeleteAsync_Sucesso()
	{
		_ = repository.DeleteAsync(Arg.Any<int>()).Returns(Customer);
		var controle = mapper.Map<Customer>(Customer);
		var retorno = await manager.DeleteAsync(Customer.Id);

		_ = await repository.Received().DeleteAsync(Arg.Any<int>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task DeleteAsync_NaoEncontrado()
	{
		_ = repository.DeleteAsync(Arg.Any<int>()).ReturnsNull();

		var retorno = await manager.DeleteAsync(1);

		_ = await repository.Received().DeleteAsync(Arg.Any<int>());
		_ = retorno.Should().BeNull();
	}
}