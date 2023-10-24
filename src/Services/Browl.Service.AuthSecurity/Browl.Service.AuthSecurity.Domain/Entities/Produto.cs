using Browl.Service.AuthSecurity.Domain.Common;

namespace Browl.Service.AuthSecurity.Domain.Entities;

public class Produto : BaseEntity
{
	public string Codigo { get; private set; }
	public int IdCategoria { get; private set; }
	public string Nome { get; private set; }
	public string Descricao { get; private set; }
	public decimal Preco { get; set; }
	public DateTime DataCadastro { get; private set; }

	public Categoria Categoria { get; private set; }

	public Produto(int id, string codigo, int idCategoria, string nome, string descricao, decimal preco)
	{
		Id = id;
		Codigo = codigo;
		IdCategoria = idCategoria;
		Nome = nome;
		Descricao = descricao;
		Preco = preco;
		DataCadastro = DateTime.Now;
	}

	public Produto(string codigo, int idCategoria, string nome, string descricao, decimal preco)
		: this(default, codigo, idCategoria, nome, descricao, preco) { }

}
