using AutoMapper;
using Browl.Core.Dtos.Habit;
using Browl.Data.Entities;

namespace Browl.Service.MarketDataCollector.Mappers;
public class HabitMapper : Profile
{
    public HabitMapper()
    {
        CreateMap<Habit, HabitDto>();
    }
}