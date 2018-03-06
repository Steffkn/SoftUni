using System;
using System.Text;

public class Book
{
    private string _title;
    private string _author;
    private decimal _price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Title
    {
        get => _title;
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            _title = value;
        }
    }

    public string Author
    {
        get => _author;
        set
        {
            var nameArgs = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameArgs.Length > 1)
            {
                if (Char.IsDigit(nameArgs[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }

            _author = value;
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            _price = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType()}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.Append($"Price: {this.Price:f2}");

        return sb.ToString();
    }
}
