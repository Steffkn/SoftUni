using System.Collections.Generic;

public interface IEngineer
{
    IEnumerable<Part> Parts { get; }
}