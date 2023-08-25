namespace Browl.Core.Dtos.Habit;

public class CreateHabitDto
{
    public string Name { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; } = default!;
}
