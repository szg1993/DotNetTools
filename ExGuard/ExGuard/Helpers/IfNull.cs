using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNull
    {
        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param)
            => Validate(param, message: null, exceptionType: null);

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, string message)
            => Validate(param, message: message, exceptionType: null);

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, Type exceptionType)
            => Validate(param, message: null, exceptionType: exceptionType);

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, string message, Type exceptionType)
            => Validate(param, message, exceptionType);

        private static TValidable Validate<TValidable>([NotNull] this TValidable param, string message, Type exceptionType)
        {
            if (param != null)
                return param;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }
    }
}