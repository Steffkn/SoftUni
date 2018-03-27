namespace P11.Threeuple.Models
{
    using P11.Threeuple.Interfaces;

    public class Threeuple<TValue1, TValue2, TValue3> : IThreeuple<TValue1, TValue2, TValue3>
    {
        public TValue1 Item1 { get; }

        public TValue2 Item2 { get; }

        public TValue3 Item3 { get; }

        public Threeuple(TValue1 item1, TValue2 item2, TValue3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public override string ToString()
        {
            return $"{this.Item1.ToString()} -> {this.Item2.ToString()} -> {this.Item3.ToString()}";
        }
    }
}
