﻿
namespace Browl.Core.Entities;
public class Especialidade
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public ICollection<Medico> Medicos { get; set; }
}