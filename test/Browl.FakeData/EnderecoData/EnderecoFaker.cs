﻿using Bogus;
using Browl.Core.Entities;

namespace Browl.FakeData.EnderecoData;

public class EnderecoFaker : Faker<Endereco>
{
    public EnderecoFaker(int clientId)
    {
        RuleFor(o => o.ClienteId, _ => clientId);
        RuleFor(o => o.Numero, f => f.Address.BuildingNumber());
        RuleFor(o => o.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
        RuleFor(o => o.Cidade, f => f.Address.City());
        RuleFor(o => o.Estado, f => f.PickRandom<Estado>());
        RuleFor(o => o.Logradouro, f => f.Address.StreetName());
        RuleFor(o => o.Complemento, f => f.Lorem.Sentence(10));
    }
}