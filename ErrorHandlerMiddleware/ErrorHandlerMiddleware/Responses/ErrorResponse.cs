namespace ErrorHandlerMiddleware.Responses
{
    public record ErrorResponse(string[] Messages, string ExceptionType)
        : ResponseBase(Messages);
}