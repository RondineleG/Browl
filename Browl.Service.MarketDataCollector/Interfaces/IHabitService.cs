using Browl.Data.Entities;

namespace Browl.Service.MarketDataCollector.Interfaces;

public interface IHabitService
{
    Task<Habit> Create(string name, string description);
    Task<Habit> GetById(int id);
    Task<IReadOnlyList<Habit>> GetAll();
}