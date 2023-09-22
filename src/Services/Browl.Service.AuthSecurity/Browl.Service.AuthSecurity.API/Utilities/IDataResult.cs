namespace Browl.Service.AuthSecurity.API.Utilities;
public interface IDataResult<out T> : IResult
{
	T Data { get; }
}
