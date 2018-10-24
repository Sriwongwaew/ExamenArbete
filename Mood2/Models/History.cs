using System;

namespace Mood2.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateWhenPlayed { get; set; }
        public string Emotion { get; set; }
        public Playlist Playlist { get; set; }

    }
}