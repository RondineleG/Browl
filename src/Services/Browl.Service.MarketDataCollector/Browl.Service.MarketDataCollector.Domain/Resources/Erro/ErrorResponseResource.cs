namespace Browl.Service.MarketDataCollector.Domain.Resources.Erro;

public class ErrorResponseResource
{
	public string Id { get; set; }
	public DateTime Data { get; set; }
	public string Mensagem { get; set; }

	public ErrorResponseResource(string id)
	{
		Id = id;
		Data = DateTime.Now;
		Mensagem = "Erro inesperado.";
	}
}