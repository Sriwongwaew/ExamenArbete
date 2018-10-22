using System;

namespace Mood2.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateWhenPlayed { get; set; }
        public Em Emotion { get; set; }
        public int EmId { get; set; }
        
       
    }
}