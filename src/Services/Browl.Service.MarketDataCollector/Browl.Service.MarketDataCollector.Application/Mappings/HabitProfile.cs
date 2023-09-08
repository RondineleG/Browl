using AutoMapper;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Habit;

namespace Browl.Service.MarketDataCollector.Application.Mappings;
public class HabitProfile : Profile
{
	public HabitProfile() => _ = CreateMap<Habit, HabitResource>();
}