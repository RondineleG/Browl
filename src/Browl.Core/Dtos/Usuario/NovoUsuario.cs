using System.Collections.Generic;

namespace Browl.Core.Dtos.Usuario;

public class NovoUsuario
{
    public string Login { get; set; }
    public string Senha { get; set; }

    public ICollection<ReferenciaFuncao> Funcoes { get; set; }
}