using System.Collections.Generic;

public interface ILeutenantGeneral
{
    IEnumerable<IPrivate> Privates { get; }
}