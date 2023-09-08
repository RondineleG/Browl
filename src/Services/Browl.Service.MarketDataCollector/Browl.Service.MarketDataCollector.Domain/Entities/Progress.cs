namespace Browl.Service.MarketDataCollector.Domain.Entities;

public class Progress
{
	public int Id { get; set; }
	public DateTime Date { get; set; }
	public int HabitId { get; set; }
	public virtual Habit Habit { get; set; } = default!;
}