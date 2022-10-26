﻿using ExGuard.Models;
using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNullOrEmptyHelpers
    {
        public static IValidatable<IEnumerable<TObject>> IfNullOrEmpty<TObject>(
            [NotNull] this IValidatable<IEnumerable<TObject>> validatable)
        {
            return Validate(validatable, message: null, exceptionType: null);
        }

        public static IValidatable<IEnumerable<TObject>> IfNullOrEmpty<TObject>(
            [NotNull] this IValidatable<IEnumerable<TObject>> validatable,
            string message)
        {
            return Validate(validatable, message: message, exceptionType: null);
        }

        public static IValidatable<IEnumerable<TObject>> IfNullOrEmpty<TObject>(
            [NotNull] this IValidatable<IEnumerable<TObject>> validatable,
            Type exceptionType)
        {
            return Validate(validatable, message: null, exceptionType: exceptionType);
        }

        public static IValidatable<IEnumerable<TObject>> IfNullOrEmpty<TObject>(
            [NotNull] this IValidatable<IEnumerable<TObject>> validatable,
            string message,
            Type exceptionType)
        {
            return Validate(validatable, message, exceptionType);
        }

        private static IValidatable<IEnumerable<TObject>> Validate<TObject>([NotNull] this IValidatable<IEnumerable<TObject>> validatable, string message, Type exceptionType)
        {
            if (validatable.Value == null || !validatable.Value.Any())
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }
    }
}