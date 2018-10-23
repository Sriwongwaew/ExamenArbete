using Mood2.Models;
using Mood2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mood2.Services
{
    public class MoodService
    {
        public PlaylistViewModel GetPlaylistByEmotion(List<Playlist> playlists)
        {
            var listOfPlaylists = new List<string>();
            var ThreePlaylists = new PlaylistViewModel();

            foreach (var item in playlists)
            {
                listOfPlaylists.Add(item.PlaylistLink);
            }

            Random rnd = new Random();
            var ResultList = listOfPlaylists.OrderBy(x => rnd.Next()).Take(3).ToList();

            ThreePlaylists.Playlist1 = ResultList[0];
            ThreePlaylists.Playlist2 = ResultList[1];
            ThreePlaylists.Playlist3 = ResultList[2];

            return ThreePlaylists;
        }
    }
}
