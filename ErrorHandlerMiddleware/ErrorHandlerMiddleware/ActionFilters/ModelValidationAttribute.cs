using ErrorHandlerMiddleware.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace ErrorHandlerMiddleware.ActionFilters
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult badRequestObjectResult
                && badRequestObjectResult.Value is ValidationProblemDetails validationProblemDetails)
            {
                var validationErrors = new StringBuilder();

                foreach (var errors in validationProblemDetails.Errors)
                    foreach (var error in errors.Value) 
                        validationErrors.AppendLine(error);

                throw new ModelValidationException(validationErrors.ToString());
            }

            base.OnResultExecuting(context);
        }
    }
}