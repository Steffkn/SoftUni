namespace P03.Iterator.Interfaces
{
    public interface IListIterator
    {
        bool HasNext();
        bool Move();
        string Print();
    }
}