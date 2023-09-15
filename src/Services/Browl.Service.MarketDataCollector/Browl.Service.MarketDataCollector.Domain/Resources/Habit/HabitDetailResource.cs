namespace Browl.Service.MarketDataCollector.Domain.Resources.Habit;

public class HabitDetailResource
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public string UserName { get; set; } = default!;
	public string GoalName { get; set; } = default!;
	public string Duration { get; set; } = default!;
}
