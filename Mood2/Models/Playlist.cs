namespace Mood2.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public Emotion Emotion { get; set; }
        public int EmotionId { get; set; }
        public string Playlistsname { get; set; }
    }
}