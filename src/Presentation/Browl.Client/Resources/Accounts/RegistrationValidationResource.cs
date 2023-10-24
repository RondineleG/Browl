using System.Text.RegularExpressions;

using FluentValidation;

namespace Browl.Client.Resources.Accounts;


public class RegistrationValidationResource : AbstractValidator<RegistrationResource>
{
	private readonly HttpClient _httpClient;
	public RegistrationValidationResource(HttpClient httpClient)
	{
		var unused4 = RuleFor(x => x.FirstName).NotEmpty();
		var unused3 = RuleFor(x => x.LastName).NotEmpty();
		var unused2 = RuleFor(x => x.Email).NotEmpty().EmailAddress()
			.MustAsync(async (value, CancellationToken) => await UniqueEmailAsync(value))
			.When(_ => !string.IsNullOrEmpty(_.Email) && Regex.IsMatch(_.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase), ApplyConditionTo.CurrentValidator)
			.WithMessage("Email Is Already Exist");
		var unused1 = RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
				.MinimumLength(6).WithMessage("Your password length must be at least 6.")
				.MaximumLength(16).WithMessage("Your password length must not exceed 16.")
				.Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
				.Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
				.Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
				.Matches(@"[\@\!\?\*\.]+").WithMessage("Your password must contain at least one (@!? *.).");
		var unused = RuleFor(x => x.ConfirmPassword).Equal(_ => _.Password).WithMessage("'Confirm Password' must be equal 'Password'");
		_httpClient = httpClient;

	}

	public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
	{
		var result =
		await ValidateAsync(ValidationContext<RegistrationResource>.CreateWithOptions((RegistrationResource)model, x => x.IncludeProperties(propertyName)));
		return result.IsValid ? (IEnumerable<string>)Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
	};

	private async Task<bool> UniqueEmailAsync(string email)
	{
		try
		{
			var url = $"/api/User/unique-user-email?email={email}";
			var response = await _httpClient.GetAsync(url);
			var unused = response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			return Convert.ToBoolean(content);
		}
		catch (Exception)
		{
			return false;
		}

	}
}
