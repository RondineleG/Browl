using Browl.Core.Dtos.Medico;

namespace Browl.Core.Interfaces.Managers;

public interface IMedicoManager
{
    Task DeleteMedicoAsync(int id);

    Task<MedicoView> GetMedicoAsync(int id);

    Task<IEnumerable<MedicoView>> GetMedicosAsync();

    Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico);

    Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
}