using Bogus;
using Bogus.Extensions.Brazil;
using Browl.Core.Dtos.Cliente;
using Browl.FakeData.EnderecoData;
using Browl.FakeData.TelefoneData;

namespace Browl.FakeData.ClienteData;

public class NovoClienteFaker : Faker<NovoCliente>
{
    public NovoClienteFaker()
    {
        RuleFor(p => p.Nome, f => f.Person.FullName);
        RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
        RuleFor(p => p.Documento, f => f.Person.Cpf());
        RuleFor(p => p.DataNascimento, f => f.Date.Past());
        RuleFor(p => p.Telefones, _ => new NovoTelefoneFaker().Generate(3));
        RuleFor(p => p.Endereco, _ => new NovoEnderecoFaker().Generate());
    }
}