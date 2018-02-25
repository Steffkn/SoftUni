using System;

public class Song
{
    private string _artistName;
    private string _songName;

    public Song(string artistName, string songName, string songLenght)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.SongLenght = GetSongLength(songLenght);
    }

    private TimeSpan GetSongLength(string songLenght)
    {
        var timeProperties = songLenght.Split(':');
        var mins = int.Parse(timeProperties[0]);
        var secs = int.Parse(timeProperties[1]);
        
        if (mins < 0 || secs < 0)
        {
            throw new InvalidSongLengthException();
        }

        if (mins > 14)
        {
            throw new InvalidSongMinutesException();
        }

        if (secs > 59)
        {
            throw new InvalidSongSecondsException();
        }

        return new TimeSpan(0, mins, secs);
    }

    public string ArtistName
    {
        get => _artistName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            _artistName = value;
        }
    }

    public string SongName
    {
        get => _songName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            _songName = value;
        }
    }

    public TimeSpan SongLenght { get; set; }
}
