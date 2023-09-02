using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Dtos.Habit;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Application.Mappers;
public class HabitMapper : Profile
{
    public HabitMapper()
    {
        CreateMap<Habit, HabitDto>();
    }
}