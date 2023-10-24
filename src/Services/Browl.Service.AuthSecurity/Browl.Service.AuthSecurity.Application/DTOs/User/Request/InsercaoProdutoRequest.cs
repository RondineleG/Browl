using Browl.Service.AuthSecurity.Domain.Entities;

namespace Browl.Service.AuthSecurity.Application.DTOs.User.Request;

public class InsercaoProdutoRequest
{
	public string Codigo { get; set; }
	public int IdCategoria { get; set; }
	public string Nome { get; set; }
	public string Descricao { get; set; }
	public decimal Preco { get; set; }

	public InsercaoProdutoRequest(string codigo, int idCategoria, string nome, string descricao, decimal preco)
	{
		Codigo = codigo;
		IdCategoria = idCategoria;
		Nome = nome;
		Descricao = descricao;
		Preco = preco;
	}

	public static Produto ConverterParaEntidade(InsercaoProdutoRequest produtoRequest) => new(
			produtoRequest.Codigo,
			produtoRequest.IdCategoria,
			produtoRequest.Nome,
			produtoRequest.Descricao,
			produtoRequest.Preco
		);
}