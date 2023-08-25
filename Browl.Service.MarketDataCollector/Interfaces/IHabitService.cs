using Browl.Data.Entities;
using Browl.Service.MarketDataCollector.Dtos.Habit;

namespace Browl.Service.MarketDataCollector.Interfaces;

public interface IHabitService
{
    Task<Habit> Create(string name, string description);
    Task<Habit> GetById(int id);
    Task<IReadOnlyList<Habit>> GetAll();
    Task DeleteById(int id);
    Task<Habit?> UpdateById(int id, UpdateHabitDto request);
}