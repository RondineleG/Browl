using AutoMapper;
using Browl.Core.Dtos.Especialidade;
using Browl.Core.Dtos.Medico;
using Browl.Core.Entities;

namespace Browl.Application.Mappings;

public class NovoMedicoMappingProfile : Profile
{
    public NovoMedicoMappingProfile()
    {
        CreateMap<NovoMedico, Medico>();
        CreateMap<Medico, MedicoView>();
        CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
        CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
        CreateMap<Especialidade, NovaEspecialidade>().ReverseMap();
        CreateMap<AlteraMedico, Medico>().ReverseMap();
    }
}