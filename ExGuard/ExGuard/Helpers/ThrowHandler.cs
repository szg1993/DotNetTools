using ExGuard.Models;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class ThrowHandler
    {
        public static IValidatable<TObject> Throw<TObject>([NotNull] this TObject validatable)
            => new Validatable<TObject>(validatable);
    }
}