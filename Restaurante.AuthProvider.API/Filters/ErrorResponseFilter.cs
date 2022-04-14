using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurante.AuthProvider.API.Model;

namespace Restaurante.AuthProvider.API.Filters;

public class ErrorResponseFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorResponse = ErrorResponse.From(context.Exception);
        context.Result = new ObjectResult(errorResponse) { StatusCode = 500 };
    }
}
