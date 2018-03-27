namespace P00.GenericBox
{
    using System;

    public class GenericBox<T>
        where T : IComparable
    {
        public GenericBox(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
