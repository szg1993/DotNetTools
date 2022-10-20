using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNull
    {       
        public static TValidatable ThrowIfNull<TValidatable>([NotNull] this TValidatable validatable)
            => Validate(validatable, message: null, exceptionType: null);

        public static TValidatable ThrowIfNull<TValidatable>([NotNull] this TValidatable validatable, string message)
            => Validate(validatable, message: message, exceptionType: null);

        public static TValidatable ThrowIfNull<TValidatable>([NotNull] this TValidatable validatable, Type exceptionType)
            => Validate(validatable, message: null, exceptionType: exceptionType);

        public static TValidatable ThrowIfNull<TValidatable>([NotNull] this TValidatable validatable, string message, Type exceptionType)
            => Validate(validatable, message, exceptionType);

        private static TValidatable Validate<TValidatable>([NotNull] this TValidatable validatable, string message, Type exceptionType)
        {
            if (validatable != null)
                return validatable;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }
    }
}