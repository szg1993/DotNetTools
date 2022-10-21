using Microsoft.AspNetCore.Http;

namespace ErrorHandlerMiddleware.Exceptions
{
    public class ModelValidationException : HttpResponseException
    {
        public ModelValidationException(string message)
            : base(message, StatusCodes.Status400BadRequest)
        { }
    }
}