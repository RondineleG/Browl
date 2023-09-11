using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Browl.Service.AuthSecurity.API.Controllers;

/// <summary>
/// Abstract base controller class that provides common functionality for API controllers.
/// </summary>
/// <remarks>
/// This abstract class defines:
/// - Erros: An ICollection property to hold a list of error strings.
/// - CustomResponse(): A protected method that returns an ActionResult with custom error handling.
/// - AddErrorProcessing(): A protected method to add an error string to the Erros collection. 
/// - ClearErrorsProcessing(): A protected method to clear the Erros collection.
/// 
/// Controllers that inherit from this base class can utilize these common members and methods for consistent error handling and responses.
/// </remarks>
[ApiController]
public abstract class MainController : Controller
{
    // Collection to store error messages
    protected ICollection<string> Errors = new List<string>();

    /// <summary>
    /// Custom response method to handle API responses
    /// </summary>
    /// <param name="result">Optional result object</param>
    /// <returns>Action result</returns>
    protected ActionResult CustomResponse(object? result = null)
    {
        // Check if the model state is valid and there are no errors
        if (ModelState.IsValid && !Errors.Any())
        {
            return Ok(result);
        }

        var allErrors = new List<string>();

        // Add model state errors to the collection
        if (ModelState.ErrorCount > 0)
        {
            var modelErrors = ModelState.Values.SelectMany(v => v.Errors);
            allErrors.AddRange(modelErrors.Select(e => e.ErrorMessage));
        }

        // Add custom errors to the collection
        allErrors.AddRange(Errors);

        // Return a bad request response with the validation problem details
        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", allErrors.ToArray() }
        }));
    }

    /// <summary>
    /// Add an error message to the collection
    /// </summary>
    /// <param name="error">Error message</param>
    protected void AddErrorProcessing(string error)
    {
        Errors.Add(error);
    }

    /// <summary>
    /// Clear all error messages from the collection
    /// </summary>
    protected void ClearErrorsProcessing()
    {
        Errors.Clear();
    }
}