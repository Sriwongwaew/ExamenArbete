using System;

namespace Mood2.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateWhenPlayed { get; set; }
        public Emotion Emotion { get; set; }
        public int EmotionId { get; set; }
        public string Playlistsname { get; set; }
    }
}