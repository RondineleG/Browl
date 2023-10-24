using Browl.Service.AuthSecurity.Domain.Entities;

namespace Browl.Service.AuthSecurity.Application.DTOs.User.Response;

/// <summary>
/// A categoria response abstraction.
/// </summary>
public class CategoriaResponse
{
	/// <summary>
	/// Id
	/// </summary>
	/// <value cref="int">int</value>
	public int Id { get; set; }
	/// <summary>
	/// Nome
	/// </summary>
	/// <value cref="string">string</value>
	public string Nome { get; set; }

	public CategoriaResponse(int id, string nome)
	{
		Id = id;
		Nome = nome;
	}

	/// <summary>
	/// Converter para response
	/// </summary>
	/// <returns cref="CategoriaResponse">CategoriaResponse</returns>
	/// <param name="categoria" cref="Categoria"></param>
	public static CategoriaResponse ConverterParaResponse(Categoria categoria) => new(
			categoria.Id,
			categoria.Nome
		);
}