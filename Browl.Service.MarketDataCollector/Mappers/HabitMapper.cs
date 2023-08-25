using AutoMapper;
using Browl.Data.Entities;
using Browl.Service.MarketDataCollector.Dtos.Habit;

namespace Browl.Service.MarketDataCollector.Mappers;
public class HabitMapper : Profile
{
    public HabitMapper()
    {
        CreateMap<Habit, HabitDto>();
    }
}