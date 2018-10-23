using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mood2.Data;

namespace Mood2.Controllers
{
    public class TestController : Controller
    {
        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext _context { get; }

        public bool CheckIfAllSpotifyLinksIsOkay()
        {
            // Hämta alla länkar från databasen
            foreach (var playlist in _context.Playlist.Select(x => x.PlaylistLink))
            {                
                HttpClient client = new HttpClient();

                var message = client.GetAsync(playlist).Result;
                if (message.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Playlist " + playlist + " not found");
            }

            return true;
        }
    }
}