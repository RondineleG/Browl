using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class CustomerUpdateProfile : Profile
{
    public CustomerUpdateProfile()
    {
        CreateMap<CustomerUpdateResource, CustomerResource>()
           .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
           .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}