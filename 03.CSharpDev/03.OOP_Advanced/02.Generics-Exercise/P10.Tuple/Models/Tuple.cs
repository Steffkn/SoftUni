namespace P10.Tuple.Models
{
    using P10.Tuple.Interfaces;

    public class Tuple<TValue1, TValue2> : ITuple<TValue1, TValue2>
    {
        public TValue1 Item1 { get; }

        public TValue2 Item2 { get; }

        public Tuple(TValue1 item1, TValue2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.Item1.ToString()} -> {this.Item2.ToString()}";
        }
    }
}
