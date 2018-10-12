using System.ComponentModel.DataAnnotations;

namespace Mood.Models
{
    public class OdeToMood
    {
        public int Id { get; set; }

        [Display(Name="Restaurant Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
    }
}
