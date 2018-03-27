namespace P11.Threeuple.Interfaces
{
    public interface IThreeuple<out TValue1, out TValue2, out TValue3>
    {
        TValue1 Item1 { get; }

        TValue2 Item2 { get; }

        TValue3 Item3 { get; }
    }
}
