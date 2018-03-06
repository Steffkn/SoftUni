using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }

    public Company Company { get; set; }

    public Car Car { get; set; }

    public List<Pokemon> Pokemons { get; set; }

    public List<Relative> Parents { get; set; }

    public List<Relative> Children { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Relative>();
        this.Children = new List<Relative>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(this.Name);
        sb.AppendLine("Company:");
        if (this.Company != null)
        {
            sb.AppendLine(this.Company.ToString());
        }
        sb.AppendLine("Car:");
        if (this.Car != null)
        {
            sb.AppendLine(this.Car.ToString());
        }
        sb.AppendLine("Pokemon:");

        foreach (var pokemon in Pokemons)
        {
            sb.AppendLine(pokemon.ToString());
        }

        sb.AppendLine("Parents:");
        foreach (var parent in Parents)
        {
            sb.AppendLine(parent.ToString());
        }

        sb.AppendLine("Children:");
        foreach (var child in Children)
        {
            sb.AppendLine(child.ToString());
        }

        return sb.ToString();
    }
}
