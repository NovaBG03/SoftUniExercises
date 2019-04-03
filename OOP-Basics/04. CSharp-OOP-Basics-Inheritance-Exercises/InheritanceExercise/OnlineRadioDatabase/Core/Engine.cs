using System;
using System.Collections.Generic;
using System.Linq;
using OnlineRadioDatabase.SongClasses;
using OnlineRadioDatabase.SongExceptions;

namespace OnlineRadioDatabase.Core
{
    class Engine
    {
        private List<Song> playlist;

        public void Run()
        {
            playlist = new List<Song>();

            int songsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < songsCount; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string artistName = data[0];
                string songName = data[1];
                int[] songLength = data[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                try
                {
                    Song song = new Song(artistName, songName, songLength);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintAddedSongs();
            PritnPlaylistLength();
        }

        private void PrintAddedSongs()
        {
            Console.WriteLine($"Songs added: {playlist.Count}");
        }

        private void PritnPlaylistLength()
        {
            int minutes = playlist.Sum(s => s.Minutes);
            int seconds = playlist.Sum(s => s.Seconds);
            int hours = 0;

            while (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }

            while (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }
}
