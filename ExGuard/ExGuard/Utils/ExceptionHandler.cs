namespace ExGuard.Utils
{
    internal static class ExceptionHandler
    {
        internal static Exception GetException(string message = null, Type exceptionType = null)
        {
            string defaultMessage = "Default message comes here";

            if (!string.IsNullOrEmpty(message) && exceptionType != null)
                return (Exception)Activator.CreateInstance(exceptionType, message);

            if (string.IsNullOrEmpty(message) && exceptionType != null)
                return (Exception)Activator.CreateInstance(exceptionType, defaultMessage);

            if (!string.IsNullOrEmpty(message) && exceptionType == null)
                return new ArgumentException(message);

            return new ArgumentException(defaultMessage); //Todo: itt is tudjon valami default messaget-t
        }
    }
}