using Browl.Data.Interfaces;

namespace Browl.Data.Entities;
public class Habit: IHasTenant
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public string Description { get; set; } = default!;
  public string TenantName { get; set; } = default!;
}