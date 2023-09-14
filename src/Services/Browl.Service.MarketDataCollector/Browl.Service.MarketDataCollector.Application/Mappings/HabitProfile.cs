using AutoMapper;
<<<<<<< HEAD

=======
>>>>>>> dev
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Habit;

namespace Browl.Service.MarketDataCollector.Application.Mappings;
public class HabitProfile : Profile
{
<<<<<<< HEAD
	public HabitProfile() => _ = CreateMap<Habit, HabitResource>();
=======
    public HabitProfile()
    {
        CreateMap<Habit, HabitResource>();
    }
>>>>>>> dev
}