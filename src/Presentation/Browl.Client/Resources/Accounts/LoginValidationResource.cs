﻿using FluentValidation;

namespace Browl.Client.Resources.Accounts;

public class LoginValidationResource : AbstractValidator<LoginResource>
{
	public LoginValidationResource()
	{
		var unused1 = RuleFor(_ => _.Email)
			.NotEmpty()
			.EmailAddress()
			.WithMessage("Invalid Email");

		var unused = RuleFor(x => x.Password).NotEmpty().WithMessage("Invalid Credentials")
				.MinimumLength(6).WithMessage("Invalid Credentials")
				.MaximumLength(16).WithMessage("Invalid Credentials")
				.Matches(@"[A-Z]+").WithMessage("Invalid Credentials")
				.Matches(@"[a-z]+").WithMessage("Invalid Credentials")
				.Matches(@"[0-9]+").WithMessage("Invalid Credentials")
				.Matches(@"[\@\!\?\*\.]+").WithMessage("Invalid Credentials");
	}

	public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
	{
		var result =
		await ValidateAsync(ValidationContext<LoginResource>.CreateWithOptions((LoginResource)model, x => x.IncludeProperties(propertyName)));
		return result.IsValid ? (IEnumerable<string>)Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
	};
}
