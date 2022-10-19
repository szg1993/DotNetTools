using System.Diagnostics.CodeAnalysis;

namespace ExGuard
{
    public static class ExGuard
    {
        //public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param)
        //{
        //    ArgumentNullException.ThrowIfNull(nameof(param));
        //    return param;
        //}

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, string message, Type exceptionType = null) 
            where TValidable : class
        {
            if (param != null)
                return param;

            if (exceptionType == null)
                throw new ArgumentNullException(message);
            
            throw GetException(message, exceptionType);          
        }

        private static Exception GetException(string message, Type type)
            => (Exception)Activator.CreateInstance(type, message);

        //private static Exception GetException<TException>(string message) where TException : Exception, new()
        //    => (TException)Activator.CreateInstance(typeof(TException), message);
    }
}