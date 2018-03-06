using System.Collections.Generic;
using System.Linq;

public class AddRemoveCollection<T> : IAddRemoveCollection<T>
{
    private IList<T> data;

    public AddRemoveCollection()
    {
        this.data = new List<T>();
    }

    public int Add(T element)
    {
        var index = 0;
        this.data.Insert(index, element);
        return index;
    }

    public T Remove()
    {
        var result = this.data.LastOrDefault();
        this.data.RemoveAt(this.data.Count - 1);
        return result;
    }
}