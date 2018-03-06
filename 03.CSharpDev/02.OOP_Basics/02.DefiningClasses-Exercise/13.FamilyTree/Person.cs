using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }

    public string BirthDay { get; set; }

    public List<Person> Parents { get; set; }

    public List<Person> Children { get; set; }

    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Name} {this.BirthDay}");

        sb.AppendLine("Parents:");
        foreach (var parent in Parents)
        {
            sb.AppendLine($"{parent.Name} {parent.BirthDay}");
        }

        sb.AppendLine("Children:");
        foreach (var child in Children)
        {
            sb.AppendLine($"{child.Name} {child.BirthDay}");
        }

        return sb.ToString();
    }
}
