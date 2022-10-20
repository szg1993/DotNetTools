using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNullOrEmpty
    {
        public static IEnumerable<TValidatable> ThrowIfNullOrEmpty<TValidatable>([NotNull] this IEnumerable<TValidatable> validatable)
            => Validate(validatable, message: null, exceptionType: null);

        public static IEnumerable<TValidatable> ThrowIfNullOrEmpty<TValidatable>([NotNull] this IEnumerable<TValidatable> validatable, string message)
            => Validate(validatable, message: message, exceptionType: null);

        public static IEnumerable<TValidatable> ThrowIfNullOrEmpty<TValidatable>([NotNull] this IEnumerable<TValidatable> validatable, Type exceptionType)
            => Validate(validatable, message: null, exceptionType: exceptionType);

        public static IEnumerable<TValidatable> ThrowIfNullOrEmpty<TValidatable>([NotNull] this IEnumerable<TValidatable> validatable, string message, Type exceptionType)
            => Validate(validatable, message, exceptionType);

        private static IEnumerable<TValidatable> Validate<TValidatable>([NotNull] this IEnumerable<TValidatable> validatable, string message, Type exceptionType)
        {
            if (validatable != null && validatable.Any())
                return validatable;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }
    }
}