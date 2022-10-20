namespace ExGuard.Models
{
    public class Validable<TValue> : IValidable<TValue>
    {
        public TValue Value { get; }

        public Validable(TValue value)
            => Value = value;  
    }
}