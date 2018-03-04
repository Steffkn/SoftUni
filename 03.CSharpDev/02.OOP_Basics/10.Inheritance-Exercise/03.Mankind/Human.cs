using System;
using System.Text;

public class Human
{
    private string _firstName;
    private string _lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            _lastName = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");

        return sb.ToString().TrimEnd();
    }
}
