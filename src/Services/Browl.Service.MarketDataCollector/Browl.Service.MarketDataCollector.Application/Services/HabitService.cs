using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.Habit;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Application.Services;

public class HabitService : IHabitService
{
	private readonly BrowlServiceMarketDataCollectorDbContext _dbContext;
	public HabitService(BrowlServiceMarketDataCollectorDbContext dbContext) => _dbContext = dbContext;

	public async Task<Habit> Create(string name, string description)
	{
		var habit = _dbContext.Habits!.Add(new Habit { Name = name, Description = description }).Entity;
		_ = await _dbContext.SaveChangesAsync();
		return habit;
	}

	public async Task<IReadOnlyList<Habit>> GetAll() => await _dbContext.Habits!.ToListAsync();

	public async Task<Habit> GetById(int id) => await _dbContext.Habits.FindAsync(id);

	public async Task DeleteById(int id)
	{
		var habit = await _dbContext.Habits!.FindAsync(id) ?? throw new ArgumentException("User not found");
		_ = _dbContext.Habits.Remove(habit);
		_ = await _dbContext.SaveChangesAsync();
	}
	public async Task<Habit?> UpdateById(int id, UpdateHabitResource request)
	{
		var habit = await _dbContext.Habits!.FindAsync(id);
		if (habit == null)
		{
			return null;
		}

		habit.Name = request.Name;
		habit.Description = request.Description;
		_ = await _dbContext.SaveChangesAsync();
		return habit;
	}

}
