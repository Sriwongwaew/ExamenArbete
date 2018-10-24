using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood2.Models;
using Mood2.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Mood2.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void all_spotify_links_should_be_okay()
        {
            HttpClient client = new HttpClient();

            string testEndpointUrl = "https://localhost:44356/Test/CheckIfAllSpotifyLinksIsOkay";

            var message = client.GetAsync(testEndpointUrl).Result;
            Assert.IsTrue(message.IsSuccessStatusCode);

        }
         
        //[TestMethod]
        //public void should_give_three_playslists_when_many_playlists_is_supplied()
        //{
        //    var x = new MoodService();
        //    var result = x.GetPlaylistByEmotion(new List<Playlist>
        //    {
        //        new Playlist{PlaylistLink="aaa"},
        //        new Playlist{PlaylistLink="bbb"},
        //        new Playlist{PlaylistLink="ccc"},
        //        new Playlist{PlaylistLink="ddd"},

        //    });

        //    Assert.IsNotNull(result.Playlist1);
        //    Assert.IsNotNull(result.Playlist2);
        //    Assert.IsNotNull(result.Playlist3);

        //}
    }
}
