using AutoMapper;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Address;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class CustomerNewProfile : Profile
{
	public CustomerNewProfile()
	{
		var unused5 = CreateMap<Customer, Customer>()
			.ForMember(d => d.Criacao, o => o.MapFrom(_ => DateTime.Now))
			.ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

		var unused4 = CreateMap<AddressNewResource, Address>();
		var unused3 = CreateMap<TelephoneNewResource, Telephone>();
		var unused2 = CreateMap<Customer, CustomerViewResource>();
		var unused1 = CreateMap<Address, AddressViewResource>();
		var unused = CreateMap<Telephone, TelephoneViewResource>();
	}
}
