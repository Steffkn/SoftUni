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
        var timeProperties = songLenght.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

        int mins;
        int secs;
        if (!int.TryParse(timeProperties[0], out mins))
        {
            throw new InvalidSongLengthException();
        }

        if (!int.TryParse(timeProperties[1], out secs))
        {
            throw new InvalidSongLengthException();
        }

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
            string name = value.Trim();
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            _artistName = name;
        }
    }

    public string SongName
    {
        get => _songName;
        set
        {
            string name = value.Trim();
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            _songName = name;
        }
    }

    public TimeSpan SongLenght { get; set; }
}
