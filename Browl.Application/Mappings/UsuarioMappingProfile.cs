using AutoMapper;
using Browl.Core.Dtos.Usuario;
using Browl.Core.Entities;

namespace Browl.Application.Mappings;

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