using Microsoft.EntityFrameworkCore;

namespace Browl.Data.Entities;

[Index(nameof(Id))]
public class Goal
{
    public int Id { get; set; }
    public int HabitId { get; set; }
    public virtual Habit Habit { get; set; } = default!;
}