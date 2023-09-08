using Browl.Service.MarketDataCollector.Domain.Enums;
using Browl.Service.MarketDataCollector.Domain.Resources.Address;
using Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

namespace Browl.Service.MarketDataCollector.Domain.Resources.Customer;

/// <summary>
/// Objeto utilizado para inserção de um novo cliente.
/// </summary>
public class CustomerResource
{
	/// <summary>
	/// Nome do cliente
	/// </summary>
	/// <example>João do Caminhão</example>
	public required string Nome { get; set; }

	/// <summary>
	/// Data do nascimento do cliente.
	/// </summary>
	/// <example>1980-01-01</example>
	public DateTime DataNascimento { get; set; }

	/// <summary>
	/// Sexo do cliente
	/// </summary>
	/// <example>M</example>
	public Gender Sexo { get; set; }

	/// <summary>
	/// Documento do cliente: CNH, CPF, RG
	/// </summary>
	/// <example>12341231312</example>
	public required string Documento { get; set; }

	public required AddressNewResource Endereco { get; set; }

	public required ICollection<TelephoneNewResource> Telefones { get; set; }
}