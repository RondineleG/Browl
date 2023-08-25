using Browl.Core.Dtos.Habit;
using Browl.Data.Entities;

namespace Browl.Core.Interfaces.Services;

public interface IHabitService
{
    Task<Habit> Create(string name, string description);
    Task<Habit> GetById(int id);
    Task<IReadOnlyList<Habit>> GetAll();
    Task DeleteById(int id);
    Task<Habit?> UpdateById(int id, UpdateHabitDto request);
}