using Microsoft.AspNetCore.Mvc.Filters;
using SupplierDueDiligence.API.Config.Exceptions;

namespace SupplierDueDiligence.API.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            string details = string.Join("; ", errors);
            throw new SupplierValidationException(details);
        }
    }
}
