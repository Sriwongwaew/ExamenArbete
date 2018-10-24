using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood2.Models
{
    public class Playlist
    {
        public int Id { get; set; }
       
        public string PlayListLink{ get; set; }

        public string PlayListName { get; set; }
        public EmotionData EmotionData { get; set; }
        public int EmotionDataId { get; set; }
        
    }
}
