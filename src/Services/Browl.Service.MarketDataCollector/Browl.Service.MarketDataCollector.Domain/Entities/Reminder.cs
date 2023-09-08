namespace Browl.Service.MarketDataCollector.Domain.Entities;

public class Reminder
{
	public int Id { get; set; }
	public Frequency Frequency { get; set; }
	public int HabitId { get; set; }
	public virtual Habit Habit { get; set; } = default!;
}
public enum Frequency { Daily, Weekly, Monthly }