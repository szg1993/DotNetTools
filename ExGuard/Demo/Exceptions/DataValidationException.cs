using Microsoft.AspNetCore.Http;

namespace Demo.Exceptions
{
    public class DataValidationException : HttpException
    {
        public DataValidationException(string message) 
            : base(message, StatusCodes.Status400BadRequest)
        { }
    }
}