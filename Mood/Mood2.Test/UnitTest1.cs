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
        
    }
}
