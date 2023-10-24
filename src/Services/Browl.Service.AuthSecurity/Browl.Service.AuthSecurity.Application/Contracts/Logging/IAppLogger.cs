namespace Browl.Service.AuthSecurity.Application.Contracts.Logging;

/// <summary>
/// I app logger
/// </summary>
public interface IAppLogger<T>
{
	void LogInformation(string message, params object[] args);
	void LogWarning(string message, params object[] args);
}
