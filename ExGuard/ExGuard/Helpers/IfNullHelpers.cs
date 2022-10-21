using ExGuard.Models;
using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNullHelpers
    {
        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable)
            => Validate(validatable, message: null, exceptionType: null);

        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable, string message)
            => Validate(validatable, message: message, exceptionType: null);

        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable, Type exceptionType)
            => Validate(validatable, message: null, exceptionType: exceptionType);

        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable, string message, Type exceptionType)
            => Validate(validatable, message, exceptionType);

        private static IValidatable<TObject> Validate<TObject>([NotNull] this IValidatable<TObject> validatable, string message, Type exceptionType)
        {
            if (validatable.Value == null)
                throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
            
            return validatable;
        }
    }
}