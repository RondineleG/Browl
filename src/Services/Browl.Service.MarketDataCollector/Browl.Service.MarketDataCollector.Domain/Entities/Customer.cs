namespace Browl.Service.MarketDataCollector.Domain.Entities;

public class Customer
{
	public int Id { get; set; }
	public required string Nome { get; set; }
	public DateTime DataNascimento { get; set; }
	public Gender Sexo { get; set; }
	public required ICollection<Telephone> Telefones { get; set; }
	public required string Documento { get; set; }
	public DateTime Criacao { get; set; }
	public DateTime? UltimaAtualizacao { get; set; }

	public required Address Endereco { get; set; }
}
