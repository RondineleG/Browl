using AutoMapper;
using Browl.Core.Dtos.Cliente;
using Browl.Core.Dtos.Endereco;
using Browl.Core.Dtos.Telefone;
using Browl.Core.Entities;

namespace Browl.Application.Mappings;

public class NovoClienteMappingProfile : Profile
{
    public NovoClienteMappingProfile()
    {
        CreateMap<NovoCliente, Cliente>()
            .ForMember(d => d.Criacao, o => o.MapFrom(_ => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

        CreateMap<NovoEndereco, Endereco>();
        CreateMap<NovoTelefone, Telefone>();
        CreateMap<Cliente, ClienteView>();
        CreateMap<Endereco, EnderecoView>();
        CreateMap<Telefone, TelefoneView>();
    }
}