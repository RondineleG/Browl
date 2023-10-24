using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.AuthSecurity.API.Models;

public class CustomProblemDetails : ProblemDetails
{
	public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
