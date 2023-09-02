using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Dtos.Usuario;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class UsuarioMappingProfile : Profile
{
    public UsuarioMappingProfile()
    {
        CreateMap<Usuario, UsuarioView>().ReverseMap();
        CreateMap<Usuario, NovoUsuario>().ReverseMap();
        CreateMap<Usuario, UsuarioLogado>().ReverseMap();
        CreateMap<Funcao, FuncaoView>().ReverseMap();
        CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
    }
}