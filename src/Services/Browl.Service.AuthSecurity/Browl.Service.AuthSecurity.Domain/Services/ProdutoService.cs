using Browl.Service.AuthSecurity.Domain.Entities;
using Browl.Service.AuthSecurity.Domain.Interfaces.Repositories;
using Browl.Service.AuthSecurity.Domain.Interfaces.Services;
using Browl.Service.AuthSecurity.Domain.Services.Shared;

namespace Browl.Service.AuthSecurity.Domain.Services;

/// <summary>
/// A produto service abstraction.
/// </summary>
public class ProdutoService : ServiceBase<Produto>, IProdutoService
{
	public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository) { }
}
