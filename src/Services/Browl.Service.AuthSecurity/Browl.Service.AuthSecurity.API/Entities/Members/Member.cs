using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Entities.Members;

public class Member : IdentityUser
{
	public Guid MemberId { get; private set; }
	public decimal TotalAssetsValue { get; set; }
	public decimal AllTimeProfit { get; set; }
	public decimal MonthlyProfit { get; set; }
	public decimal WeeklyProfit { get; set; }
	public decimal DailyProfit { get; set; }
}
