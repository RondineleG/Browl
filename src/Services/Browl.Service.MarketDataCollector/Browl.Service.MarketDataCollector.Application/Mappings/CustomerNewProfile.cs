using AutoMapper;
<<<<<<< HEAD

=======
>>>>>>> dev
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Address;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class CustomerNewProfile : Profile
{
<<<<<<< HEAD
	public CustomerNewProfile()
	{
		_ = CreateMap<Customer, Customer>()
			.ForMember(d => d.Criacao, o => o.MapFrom(_ => DateTime.Now))
			.ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

		_ = CreateMap<AddressNewResource, Address>();
		_ = CreateMap<TelephoneNewResource, Telephone>();
		_ = CreateMap<Customer, CustomerViewResource>();
		_ = CreateMap<Address, AddressViewResource>();
		_ = CreateMap<Telephone, TelephoneViewResource>();
	}
=======
    public CustomerNewProfile()
    {
        CreateMap<Customer, Customer>()
            .ForMember(d => d.Criacao, o => o.MapFrom(_ => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

        CreateMap<AddressNewResource, Address>();
        CreateMap<TelephoneNewResource, Telephone>();
        CreateMap<Customer, CustomerViewResource>();
        CreateMap<Address, AddressViewResource>();
        CreateMap<Telephone, TelephoneViewResource>();
    }
>>>>>>> dev
}