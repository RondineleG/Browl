using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.AuthSecurity.API.Controllers.Base;

/// <summary>
/// Abstract base controller class that provides common functionality for API controllers.
/// </summary>
/// <remarks>
/// This abstract class defines:
/// - Errors: An IList property to hold a list of error strings.
/// - CustomResponse(): A protected method that returns an ActionResult with custom error handling.
/// - AddErrorProcessing(): A protected method to add an error string to the Errors collection. 
/// - ClearErrorsProcessing(): A protected method to clear the Errors collection.
/// 
/// Controllers that inherit from this base class can utilize these common members and methods for consistent error handling and responses.
/// </remarks>
[ApiController]
public abstract class MainController : Controller
{
	// Collection to store error messages
	protected IList<string> Errors = new List<string>();

	/// <summary>
	/// Custom response method to handle API responses
	/// </summary>
	/// <param name="result">Optional result object</param>
	/// <returns>Action result</returns>
	protected ActionResult CustomResponse(object? result = null)
	{
		// Check if the model state is valid and there are no errors
		if (ModelState.IsValid && Errors.Count == 0)
		{
			return Ok(result);
		}

		var errorDictionary = new Dictionary<string, string[]>();

		// Add model state errors to the dictionary
		if (ModelState.ErrorCount > 0)
		{
			var modelErrors = ModelState.Values.SelectMany(v => v.Errors);
			errorDictionary.Add("Messages", modelErrors.Select(e => e.ErrorMessage).ToArray());
		}

		// Add custom errors to the dictionary
		if (Errors.Count > 0)
		{
			errorDictionary.Add("Messages", Errors.ToArray());
		}

		// Return a bad request response with the validation problem details
		return BadRequest(new ValidationProblemDetails(errorDictionary));
	}

	/// <summary>
	/// Add an error message to the collection
	/// </summary>
	/// <param name="error">Error message</param>
	protected void AddErrorProcessing(string error) => Errors.Add(error);

	/// <summary>
	/// Clear all error messages from the collection
	/// </summary>
	protected void ClearErrorsProcessing() => Errors.Clear();
}
