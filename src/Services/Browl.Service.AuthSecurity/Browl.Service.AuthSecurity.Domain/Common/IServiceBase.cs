namespace Browl.Service.AuthSecurity.Domain.Common;

/// <summary>
/// I service base
/// </summary>
public interface IServiceBase<TEntity> : IDisposable where TEntity : BaseEntity
{
	Task<IEnumerable<TEntity>> ObterTodosAsync();
	Task<TEntity?> ObterPorIdAsync(int id);
	Task<object> AdicionarAsync(TEntity objeto);
	Task AtualizarAsync(TEntity objeto);
	Task RemoverAsync(TEntity objeto);
	Task RemoverPorIdAsync(int id);
}
