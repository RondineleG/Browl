
using Browl.Data;
using Browl.Data.Entities;
using Browl.Service.MarketDataCollector.Dtos.Habit;
using Browl.Service.MarketDataCollector.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector;

public class HabitService : IHabitService
{
    private readonly BrowlDbContext _dbContext;
    public HabitService(BrowlDbContext dbContext) => _dbContext = dbContext;
    public async Task<Habit> Create(string name, string description)
    {
        var habit = _dbContext.Habits!.Add(new Habit { Name = name, Description = description }).Entity;
        await _dbContext.SaveChangesAsync();
        return habit;
    }

    public async Task<IReadOnlyList<Habit>> GetAll() => await _dbContext.Habits!.ToListAsync();

    public async Task<Habit> GetById(int id) => await _dbContext.Habits.FindAsync(id);

    public async Task DeleteById(int id)
    {
        var habit = await _dbContext.Habits!.FindAsync(id) ?? throw new ArgumentException("User not found");
        _dbContext.Habits.Remove(habit);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Habit?> UpdateById(int id, UpdateHabitDto request)
    {
        var habit = await _dbContext.Habits!.FindAsync(id);
        if (habit == null) return null;
        habit.Name = request.Name;
        habit.Description = request.Description;
        await _dbContext.SaveChangesAsync();
        return habit;
    }

}
