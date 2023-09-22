namespace Browl.Service.AuthSecurity.API.Utilities;
public interface IResult
{
	bool Success { get; }
	string Message { get; }
}
