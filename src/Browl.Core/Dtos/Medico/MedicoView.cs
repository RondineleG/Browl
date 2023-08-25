using Browl.Core.Dtos.Especialidade;

namespace Browl.Core.Dtos.Medico;

public class MedicoView
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CRM { get; set; }

    public ICollection<EspecialidadeView> Especialidades { get; set; }
}