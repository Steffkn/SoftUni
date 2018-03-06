using System;
using System.Text;

public abstract class Animal : ISoundProducer
{
    private string _name;
    private int _age;
    private string _gender;

    protected Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    // name, an age and a gender
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidValueMessage);
            }
            _name = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidValueMessage);
            }
            _age = value;
        }
    }

    public string Gender
    {
        get => _gender;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidValueMessage);
            }
            _gender = value;
        }

    }

    public virtual void ProduceSound()
    { }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.GetType().ToString());
        sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
        return sb.ToString().TrimEnd();
    }
}
