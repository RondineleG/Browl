namespace Browl.Service.MarketDataCollector.Domain.Resources.Habit;

public class GetGoodHabitDetailResource
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required string UserName { get; set; }
	public required string GoalName { get; set; }
	public required string Duration { get; set; }
}
