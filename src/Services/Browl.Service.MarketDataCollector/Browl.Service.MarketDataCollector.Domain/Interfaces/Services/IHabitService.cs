using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Habit;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

public interface IHabitService
{
	Task<Habit> Create(string name, string description);
	Task<Habit> GetById(int id);
	Task<IReadOnlyList<Habit>> GetAll();
	Task DeleteById(int id);
	Task<Habit?> UpdateById(int id, UpdateHabitResource request);
}