using ExGuard.Models;
using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNullHelpers
    {
        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable) where TObject : class
            => Validate(validatable, message: null, exceptionType: null);

        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable, string message) where TObject : class
            => Validate(validatable, message: message, exceptionType: null);

        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable, Type exceptionType) where TObject : class
            => Validate(validatable, message: null, exceptionType: exceptionType);

        public static IValidatable<TObject> IfNull<TObject>([NotNull] this IValidatable<TObject> validatable, string message, Type exceptionType) where TObject : class
            => Validate(validatable, message, exceptionType);

        private static IValidatable<TObject> Validate<TObject>([NotNull] this IValidatable<TObject> validatable, string message, Type exceptionType) where TObject : class
        {
            if (validatable.Value == null)
                throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
            
            return validatable;
        }
    }
}