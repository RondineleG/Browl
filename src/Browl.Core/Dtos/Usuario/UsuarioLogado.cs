﻿namespace Browl.Core.Dtos.Usuario;

public class UsuarioLogado
{
    public string Login { get; set; }
    public ICollection<FuncaoView> Funcoes { get; set; }
    public string Token { get; set; }
}