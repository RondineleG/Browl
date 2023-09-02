using Browl.Service.MarketDataCollector.Domain.Dtos.Habit;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

public interface IHabitService
{
    Task<Habit> Create(string name, string description);
    Task<Habit> GetById(int id);
    Task<IReadOnlyList<Habit>> GetAll();
    Task DeleteById(int id);
    Task<Habit?> UpdateById(int id, UpdateHabitDto request);
}