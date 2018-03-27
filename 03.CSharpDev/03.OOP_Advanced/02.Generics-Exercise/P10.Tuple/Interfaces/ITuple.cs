namespace P10.Tuple.Interfaces
{
    public interface ITuple<out TValue1, out TValue2>
    {
        TValue1 Item1 { get; }

        TValue2 Item2 { get; }
    }

}
