namespace Browl.Service.MarketDataCollector.Domain.Resources.Habit;

public class CreateHabitResource
{
    public string Name { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; } = default!;
}
