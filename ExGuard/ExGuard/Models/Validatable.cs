namespace ExGuard.Models
{
    public class Validatable<TValue> : IValidatable<TValue>
    {
        public TValue Value { get; }

        public Validatable(TValue value)
            => Value = value;  
    }
}