using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var playList = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            var songArgs = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var artistName = songArgs[0].Trim();
                var songName = songArgs[1].Trim();
                var songLenght = songArgs[2].Trim();

                var song = new Song(artistName, songName, songLenght);

                playList.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var plTime = new TimeSpan();
        foreach (var song in playList)
        {
            plTime = plTime.Add(song.SongLenght);
        }

        Console.WriteLine($"Songs added: {playList.Count}");
        Console.WriteLine($"Playlist length: {plTime.Hours}h {plTime.Minutes}m {plTime.Seconds}s");
    }
}
