using Bogus;
using Browl.Core.Dtos.Telefone;

namespace Browl.FakeData.TelefoneData;

public class NovoTelefoneFaker : Faker<NovoTelefone>
{
    public NovoTelefoneFaker()
    {
        RuleFor(p => p.Numero, f => f.Person.Phone);
    }
}