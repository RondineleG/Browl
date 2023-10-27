using FluentValidation;

namespace Browl.Service.Services;
public class BaseService
{
	internal void Validate<T>(T value, AbstractValidator<T> validator)
	{
		if(value == null)
			throw new ArgumentNullException("Missing Data");
		
		validator.ValidateAndThrow(value);
	}

}
