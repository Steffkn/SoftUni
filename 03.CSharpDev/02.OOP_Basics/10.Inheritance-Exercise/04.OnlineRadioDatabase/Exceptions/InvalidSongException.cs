using System;

public class InvalidSongException : Exception
{
    public InvalidSongException()
        : this("Invalid song.")
    {}

    public InvalidSongException(string message) : base(message)
    {
    }
}
