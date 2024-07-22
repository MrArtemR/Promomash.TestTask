namespace Promomash.TestTask.Domain.Common
{
    public abstract record ValueObject : IEquatable<ValueObject>
    {

        public virtual bool Equals(ValueObject other) =>
            other is not null && ValuesAreEqual(other);

        public override int GetHashCode() =>
            GetAtomicValues().Aggregate(
                default(int),
                (hashcode, value) =>
                    HashCode.Combine(hashcode, value.GetHashCode()));

        protected abstract IEnumerable<object> GetAtomicValues();

        private bool ValuesAreEqual(ValueObject valueObject) =>
            GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
    }
}
