public class Robot : IEntity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public Robot(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }
}
