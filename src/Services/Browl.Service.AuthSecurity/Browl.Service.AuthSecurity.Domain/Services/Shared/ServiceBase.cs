using Browl.Service.AuthSecurity.Domain.Common;

namespace Browl.Service.AuthSecurity.Domain.Services.Shared;

/// <summary>
/// A service base abstraction.
/// </summary>
public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
{
	private readonly IRepositoryBase<TEntity> _repositoryBase;

	public ServiceBase(IRepositoryBase<TEntity> repositoryBase) =>
		_repositoryBase = repositoryBase;

	/// <summary>
	/// Obter todos async
	/// </summary>
	/// <returns cref="Task{T}">Task&lt;IEnumerable&lt;TEntity&gt;&gt;</returns>
	public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
		await _repositoryBase.ObterTodosAsync();

	/// <summary>
	/// Obter por id async
	/// </summary>
	/// <returns cref="Task{T}">Task&lt;TEntity?&gt;</returns>
	/// <param name="id" cref="int"></param>
	public virtual async Task<TEntity?> ObterPorIdAsync(int id) =>
		await _repositoryBase.ObterPorIdAsync(id);

	/// <summary>
	/// Adicionar async
	/// </summary>
	/// <returns cref="Task{T}">Task&lt;object&gt;</returns>
	/// <param name="objeto" cref="TEntity"></param>
	public virtual async Task<object> AdicionarAsync(TEntity objeto) =>
		await _repositoryBase.AdicionarAsync(objeto);

	/// <summary>
	/// Atualizar async
	/// </summary>
	/// <returns cref="Task">Task</returns>
	/// <param name="objeto" cref="TEntity"></param>
	public virtual async Task AtualizarAsync(TEntity objeto) =>
		await _repositoryBase.AtualizarAsync(objeto);

	/// <summary>
	/// Remover async
	/// </summary>
	/// <returns cref="Task">Task</returns>
	/// <param name="objeto" cref="TEntity"></param>
	public virtual async Task RemoverAsync(TEntity objeto) =>
		await _repositoryBase.RemoverAsync(objeto);

	/// <summary>
	/// Remover por id async
	/// </summary>
	/// <returns cref="Task">Task</returns>
	/// <param name="id" cref="int"></param>
	public virtual async Task RemoverPorIdAsync(int id) =>
		await _repositoryBase.RemoverPorIdAsync(id);

	/// <summary>
	/// Dispose
	/// </summary>
	public void Dispose() =>
		_repositoryBase.Dispose();
}
