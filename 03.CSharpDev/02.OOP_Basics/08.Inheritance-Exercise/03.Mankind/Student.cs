using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string _facNumber;

    public string FacNumber
    {
        get => _facNumber;
        set
        {
            if (value.Length < 5 || value.Length > 10 || value.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            _facNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facNumer) : base(firstName, lastName)
    {
        this.FacNumber = facNumer;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Faculty number: {this.FacNumber}");
        return sb.ToString().TrimEnd();
    }
}
