using Microsoft.AspNetCore.Mvc;
using Mood2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood2.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Models.Playlist> GetPlayList()
        {
            var playlist = _context.Playlist.ToList();
            return playlist;
        }
    }
}
