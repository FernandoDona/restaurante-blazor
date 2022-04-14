using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restaurante.AuthProvider.API.Model;

public record ErrorResponse(long Code, string Message, string Target, ErrorResponse InnerError, string[] Details)
{
    public static ErrorResponse From(Exception e)
    {
        return new ErrorResponse(e.HResult, e.Message, e.TargetSite.ToString(), From(e.InnerException), null);
    }

    public static ErrorResponse FromModelState(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(m => m.Errors);

        return new ErrorResponse(100, "Houve erro(s) na requisição. Verifique os detalhes.", null, null, errors.Select(e => e.ErrorMessage).ToArray());
    }
}
