using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mood2.Data;
using Mood2.Models;

namespace Mood2.Controllers
{
    public class PlaylistController : Controller
    {
        private ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AllaSpellistor()
        {
            List<Playlist> ShowAllPlaylists = _context.Playlist.Include(x=> x.EmotionData).ToList();
            return View(ShowAllPlaylists);
        }

        public IActionResult GladaSpellistor()
        {
            List<Playlist> ShowAllHappyPlaylists = _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == "happiness").ToList();
            return View(ShowAllHappyPlaylists);
        }

        public IActionResult LedsnaSpellistor()
        {
            List<Playlist> ShowAllSadPlaylists = _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == "sadness").ToList();
            return View(ShowAllSadPlaylists);
        }

        public IActionResult ArgaSpellistor()
        {
            List<Playlist> ShowAllMadPlaylists = _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == "anger").ToList();
            return View(ShowAllMadPlaylists);
        }

        public IActionResult RäddaSpellistor()
        {
            List<Playlist> ShowAllFearPlaylists = _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == "fear").ToList();
            return View(ShowAllFearPlaylists);
        }

        public IActionResult NeutralaSpellistor()
        {
            List<Playlist> ShowAllNeutralPlaylists = _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == "neutral").ToList();
            return View(ShowAllNeutralPlaylists);
        }

        public IActionResult FörvånadSpellistor()
        {
            List<Playlist> ShowAllSurprisedPlaylists = _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == "surprise").ToList();
            return View(ShowAllSurprisedPlaylists);
        }
    }
}