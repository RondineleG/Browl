using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Browl.Service.AuthSecurity.API.Controllers;

[ApiController]
public abstract class MainController : Controller
{
    protected ICollection<string> Erros = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        return IsValid()
            ? Ok(result)
            : BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", Erros.ToArray() }
        }));
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        IEnumerable<ModelError> erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (ModelError? erro in erros)
        {
            AddErrorProcessing(erro.ErrorMessage);
        }

        return CustomResponse();
    }

    protected bool IsValid()
    {
        return !Erros.Any();
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
