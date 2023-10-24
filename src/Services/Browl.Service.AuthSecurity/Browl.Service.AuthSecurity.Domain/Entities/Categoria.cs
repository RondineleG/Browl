using Browl.Service.AuthSecurity.Domain.Common;

namespace Browl.Service.AuthSecurity.Domain.Entities;

/// <summary>
/// A categoria abstraction.
/// </summary>
public class Categoria : BaseEntity
{
	/// <summary>
	/// Nome
	/// </summary>
	/// <value cref="string">string</value>
	public string Nome { get; set; }

	/// <summary>
	/// Produtos
	/// </summary>
	/// <value cref="ICollection{T}">ICollection&lt;Produto&gt;</value>
	public ICollection<Produto> Produtos { get; private set; }

	public Categoria(int id, string nome)
	{
		Id = id;
		Nome = nome;
	}
}
