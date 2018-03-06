using System.Collections.Generic;
using System.Linq;

public class MyList<T> : IMyList<T>
{
    private List<T> data;

    public MyList()
    {
        this.data = new List<T>();
        this.Used = 0;
    }

    public int Used { get; private set; }

    public int Add(T element)
    {
        var index = 0;
        this.data.Insert(index, element);
        this.Used++;
        return index;
    }

    public T Remove()
    {
        var removedItem = this.data.FirstOrDefault();
        this.data.RemoveAt(0);
        this.Used--;
        return removedItem;
    }
}