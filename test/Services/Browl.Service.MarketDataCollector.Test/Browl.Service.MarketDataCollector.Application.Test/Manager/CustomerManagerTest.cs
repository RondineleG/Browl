using AutoMapper;
using Browl.Service.MarketDataCollector.Application.Implementation;
using Browl.Service.MarketDataCollector.Application.Mappings;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.FakeData.CustomerData;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Browl.Service.MarketDataCollector.Application.Test.Manager;

public class CustomerManagerTest
{
	private readonly ICustomerRepository repository;
	private readonly ILogger<CustomerManager> logger;
	private readonly IMapper mapper;
	private readonly ICustomerManager manager;
	private readonly Customer Customer;
	private readonly Customer NovoCustomer;
	private readonly Customer AlteraCustomer;
	private readonly CustomerFaker CustomerFaker;
	private readonly CustomerNewFaker NovoCustomerFaker;
	private readonly CustomerUpdateFaker AlteraCustomerFaker;

	public CustomerManagerTest()
	{
		repository = Substitute.For<ICustomerRepository>();
		logger = Substitute.For<ILogger<CustomerManager>>();
		mapper = new MapperConfiguration(p => p.AddProfile<CustomerNewProfile>()).CreateMapper();
		manager = new CustomerManager(repository, mapper, logger);
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
		List<Customer> listaCustomers = CustomerFaker.Generate(10);
		_ = repository.GetAsync().Returns(listaCustomers);
		IEnumerable<Customer> controle = mapper.Map<IEnumerable<Customer>, IEnumerable<Customer>>(listaCustomers);
		IEnumerable<Domain.Resources.Customer.CustomerViewResource> retorno = await manager.GetAsync();

		_ = await repository.Received().GetAsync();
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task GetCustomersAsync_Vazio()
	{
		_ = repository.GetAsync().Returns(new List<Customer>());

		IEnumerable<Domain.Resources.Customer.CustomerViewResource> retorno = await manager.GetAsync();

		_ = await repository.Received().GetAsync();
		_ = retorno.Should().BeEquivalentTo(new List<Customer>());
	}

	[Fact]
	public async Task GetAsync_Sucesso()
	{
		_ = repository.GetAsync(Arg.Any<int>()).Returns(Customer);
		Customer controle = mapper.Map<Customer>(Customer);
		Domain.Resources.Customer.CustomerViewResource retorno = await manager.GetAsync(Customer.Id);

		_ = await repository.Received().GetAsync(Arg.Any<int>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task GetAsync_NaoEncontrado()
	{
		_ = repository.GetAsync(Arg.Any<int>()).Returns(new Customer());
		Customer controle = mapper.Map<Customer>(new Customer());
		Domain.Resources.Customer.CustomerViewResource retorno = await manager.GetAsync(1);

		_ = await repository.Received().GetAsync(Arg.Any<int>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task PostAsync_Sucesso()
	{
		_ = repository.PostAsync(Arg.Any<Customer>()).Returns(Customer);
		Customer controle = mapper.Map<Customer>(Customer);
		var retorno = await manager.PostAsync(NovoCustomer);

		_ = await repository.Received().PostAsync(Arg.Any<Customer>());
		retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task PutAsync_Sucesso()
	{
		_ = repository.PutAsync(Arg.Any<Customer>()).Returns(Customer);
		Customer controle = mapper.Map<Customer>(Customer);
		var retorno = await manager.PutAsync(AlteraCustomer);

		_ = await repository.Received().PutAsync(Arg.Any<Customer>());
		retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task PutAsync_NaoEncontrado()
	{
		_ = repository.PutAsync(Arg.Any<Customer>()).ReturnsNull();

		var retorno = await manager.PutAsync(AlteraCustomer);

		_ = await repository.Received().PutAsync(Arg.Any<Customer>());
		retorno.Should().BeNull();
	}

	[Fact]
	public async Task DeleteAsync_Sucesso()
	{
		_ = repository.DeleteAsync(Arg.Any<int>()).Returns(Customer);
		Customer controle = mapper.Map<Customer>(Customer);
		Domain.Resources.Customer.CustomerResource retorno = await manager.DeleteAsync(Customer.Id);

		_ = await repository.Received().DeleteAsync(Arg.Any<int>());
		_ = retorno.Should().BeEquivalentTo(controle);
	}

	[Fact]
	public async Task DeleteAsync_NaoEncontrado()
	{
		_ = repository.DeleteAsync(Arg.Any<int>()).ReturnsNull();

		Domain.Resources.Customer.CustomerResource retorno = await manager.DeleteAsync(1);

		_ = await repository.Received().DeleteAsync(Arg.Any<int>());
		_ = retorno.Should().BeNull();
	}
}