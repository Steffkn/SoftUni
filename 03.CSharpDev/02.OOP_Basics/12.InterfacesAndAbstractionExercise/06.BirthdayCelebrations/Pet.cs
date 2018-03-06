public class Pet : IEntity, IBirthable
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string BirthDate { get; set; }

    public Pet(string name, string birthDate)
    {
        Id = "petId";
        Name = name;
        BirthDate = birthDate;
    }
}
