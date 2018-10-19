using System.ComponentModel.DataAnnotations;

namespace Mood2.Models
{
    public class OdeToMood
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Em
    {
        public double Value { get; set; }
        public string EmotionName { get; set; }
    }
}
