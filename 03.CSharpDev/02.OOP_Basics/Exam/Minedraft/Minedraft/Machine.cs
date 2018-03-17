public abstract class Machine
{
    private string id;

    protected Machine(string id)
    {
        this.id = id;
    }

    public string Id => id;
}