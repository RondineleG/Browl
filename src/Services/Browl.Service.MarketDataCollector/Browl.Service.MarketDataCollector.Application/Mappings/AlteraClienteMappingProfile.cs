using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Dtos.Cliente;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class AlteraClienteMappingProfile : Profile
{
    public AlteraClienteMappingProfile()
    {
        CreateMap<AlteraCliente, Cliente>()
           .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
           .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}