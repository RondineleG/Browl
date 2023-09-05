using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Address;
using Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class CustomerNewProfile : Profile
{
    public CustomerNewProfile()
    {
        CreateMap<Domain.Entities.Customer, Domain.Entities.Customer>()
            .ForMember(d => d.Criacao, o => o.MapFrom(_ => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

        CreateMap<AddressNewResource, Address>();
        CreateMap<TelephoneNewResource, Telephone>();
        CreateMap<Domain.Entities.Customer, CustomerView>();
        CreateMap<Address, AddressViewResource>();
        CreateMap<Telephone, TelephoneViewResource>();
    }
}