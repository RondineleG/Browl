using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Browl.Service.AuthSecurity.API.Controllers;

[ApiController]
public abstract class MainController : Controller
{
    protected ICollection<string> Erros = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        if (ModelState.IsValid && !Erros.Any())
        {
            return Ok(result);
        }

        var allErrors = new List<string>();
        if (ModelState.ErrorCount > 0)
        {
            var modelErrors = ModelState.Values.SelectMany(v => v.Errors);
            allErrors.AddRange(modelErrors.Select(e => e.ErrorMessage));
        }

        allErrors.AddRange(Erros);

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", allErrors.ToArray() }
        }));
    }

    protected void AddErrorProcessing(string erro)
    {
        Erros.Add(erro);
    }

    protected void ClearErrorsProcessing()
    {
        Erros.Clear();
    }
}
