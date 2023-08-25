using Bogus;
using Bogus.Extensions.Brazil;
using Browl.Core.Dtos.Cliente;
using Browl.FakeData.EnderecoData;
using Browl.FakeData.TelefoneData;

namespace Browl.FakeData.ClienteData;

public class ClienteViewFaker : Faker<ClienteView>
{
    public ClienteViewFaker()
    {
        var id = new Faker().Random.Number(1, 999999);
        _ = RuleFor(p => p.Id,
            _ => id);
        RuleFor(p => p.Nome, f => f.Person.FullName);
        RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
        RuleFor(p => p.Documento, f => f.Person.Cpf());
        RuleFor(p => p.Criacao, f => f.Date.Past());
        RuleFor(p => p.UltimaAtualizacao, f => f.Date.Past());
        RuleFor(p => p.DataNascimento, f => f.Date.Past());
        RuleFor(p => p.Telefones, _ => new TelefoneViewFaker().Generate(3));
        RuleFor(p => p.Endereco, _ => new EnderecoViewFaker().Generate());
    }
}