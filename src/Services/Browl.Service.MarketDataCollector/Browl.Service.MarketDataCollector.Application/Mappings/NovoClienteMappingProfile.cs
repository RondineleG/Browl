using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Dtos.Cliente;
using Browl.Service.MarketDataCollector.Domain.Dtos.Endereco;
using Browl.Service.MarketDataCollector.Domain.Dtos.Telefone;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

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