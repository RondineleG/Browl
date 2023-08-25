using AutoMapper;
using Browl.Core.Dtos.Cliente;
using Browl.Core.Entities;

namespace Browl.Application.Mappings;

public class AlteraClienteMappingProfile : Profile
{
    public AlteraClienteMappingProfile()
    {
        CreateMap<AlteraCliente, Cliente>()
           .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
           .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}