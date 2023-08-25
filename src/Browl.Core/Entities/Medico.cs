﻿
namespace Browl.Core.Entities;
public class Medico
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CRM { get; set; }

    public ICollection<Especialidade> Especialidades { get; set; }

    public Medico()
    {
        Especialidades = new HashSet<Especialidade>();
    }
}