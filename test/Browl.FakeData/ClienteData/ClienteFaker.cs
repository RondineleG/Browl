﻿using Bogus;
using Bogus.Extensions.Brazil;
using Browl.Core.Entities;
using Browl.FakeData.EnderecoData;
using Browl.FakeData.TelefoneData;

namespace Browl.FakeData.ClienteData;

public class ClienteFaker : Faker<Cliente>
{
    public ClienteFaker()
    {
        var id = new Faker().Random.Number(1, 999999);
        RuleFor(o => o.Id, _ => id);
        RuleFor(o => o.Nome, f => f.Person.FullName);
        RuleFor(o => o.Sexo, f => f.PickRandom<Sexo>());
        RuleFor(o => o.Documento, f => f.Person.Cpf());
        RuleFor(o => o.Criacao, f => f.Date.Past());
        RuleFor(o => o.UltimaAtualizacao, f => f.Date.Past());
        RuleFor(o => o.Telefones, _ => new TelefoneFaker(id).Generate(3));
        RuleFor(o => o.Endereco, _ => new EnderecoFaker(id).Generate());
    }
}