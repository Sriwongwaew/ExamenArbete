using System;

namespace Mood2.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateWhenPlayed { get; set; }
        public EmotionData EmotionData { get; set; }
        public int EmotionDataId { get; set; }
        
       
    }
}