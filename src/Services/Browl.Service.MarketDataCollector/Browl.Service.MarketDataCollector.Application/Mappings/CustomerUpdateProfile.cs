﻿using AutoMapper;
<<<<<<< HEAD

=======
>>>>>>> dev
using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class CustomerUpdateProfile : Profile
{
<<<<<<< HEAD
	public CustomerUpdateProfile() => _ = CreateMap<CustomerUpdateResource, CustomerViewResource>()
		   .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
		   .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
=======
    public CustomerUpdateProfile()
    {
        CreateMap<CustomerUpdateResource, CustomerViewResource>()
           .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
           .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
>>>>>>> dev
}