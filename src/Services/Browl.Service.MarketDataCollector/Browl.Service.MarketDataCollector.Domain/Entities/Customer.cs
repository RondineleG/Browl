namespace Browl.Service.MarketDataCollector.Domain.Entities;

public class Customer
{
<<<<<<< HEAD
	public int Id { get; set; }
	public string Nome { get; set; }
	public DateTime DataNascimento { get; set; }
	public Gender Sexo { get; set; }
	public ICollection<Telephone> Telefones { get; set; }
	public string Documento { get; set; }
	public DateTime Criacao { get; set; }
	public DateTime? UltimaAtualizacao { get; set; }

	public Address Endereco { get; set; }
}
=======
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public Gender Sexo { get; set; }
    public ICollection<Telephone> Telefones { get; set; }
    public string Documento { get; set; }
    public DateTime Criacao { get; set; }
    public DateTime? UltimaAtualizacao { get; set; }

    public Address Endereco { get; set; }
}
>>>>>>> dev
