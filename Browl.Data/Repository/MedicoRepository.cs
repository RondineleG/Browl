using Browl.Core.Entities;
using Browl.Core.Interfaces.Repositories;
using Browl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Browl.Data.Repository;

public class MedicoRepository : IMedicoRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public MedicoRepository(BrowlDbContext browlDbContext)
    {
        _browlDbContext = browlDbContext;
    }

    public async Task<IEnumerable<Medico>> GetMedicosAsync()
    {
        return await _browlDbContext.Medicos
          .Include(p => p.Especialidades)
          .AsNoTracking().ToListAsync();
    }

    public async Task<Medico> GetMedicoAsync(int id)
    {
        return await _browlDbContext.Medicos
            .Include(p => p.Especialidades)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Medico> InsertMedicoAsync(Medico medico)
    {
        await InsertMedicoEspecilidades(medico);
        await _browlDbContext.Medicos.AddAsync(medico);
        await _browlDbContext.SaveChangesAsync();
        return medico;
    }

    private async Task InsertMedicoEspecilidades(Medico medico)
    {
        var especialidadesConsultadas = new List<Especialidade>();
        foreach (var especialidade in medico.Especialidades)
        {
            var especialidadeConsultada = await _browlDbContext.Especialidades.FindAsync(especialidade.Id);
            especialidadesConsultadas.Add(especialidadeConsultada);
        }
        medico.Especialidades = especialidadesConsultadas;
    }

    public async Task<Medico> UpdateMedicoAsync(Medico medico)
    {
        var medicoConsultado = await _browlDbContext.Medicos
                                    .Include(p => p.Especialidades)
                                    .SingleOrDefaultAsync(p => p.Id == medico.Id);
        if (medicoConsultado == null)
        {
            return null;
        }
        _browlDbContext.Entry(medicoConsultado).CurrentValues.SetValues(medico);
        await UpdateMedicoEspecialidades(medico, medicoConsultado);
        await _browlDbContext.SaveChangesAsync();
        return medicoConsultado;
    }

    private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
    {
        medicoConsultado.Especialidades.Clear();
        foreach (var especialidade in medico.Especialidades)
        {
            var especialidadeConsultada = await _browlDbContext.Especialidades.FindAsync(especialidade.Id);
            medicoConsultado.Especialidades.Add(especialidadeConsultada);
        }
    }

    public async Task<Medico> DeleteMedicoAsync(int id)
    {
        var medicoConsultado = await _browlDbContext.Medicos.FindAsync(id);
        if (medicoConsultado == null)
        {
            return null;
        }
        var medicoRemovido = _browlDbContext.Medicos.Remove(medicoConsultado);
        await _browlDbContext.SaveChangesAsync();
        return medicoRemovido.Entity;
    }
}