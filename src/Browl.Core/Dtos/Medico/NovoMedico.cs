using Browl.Core.Dtos.Especialidade;

namespace Browl.Core.Dtos.Medico;

public class NovoMedico
{
    public string Nome { get; set; }
    public int CRM { get; set; }
    public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
}