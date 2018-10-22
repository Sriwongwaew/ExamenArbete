using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mood2.Models;
using Mood2.Models.FaceApiData;
using Mood2.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Mood2.Data;
using Microsoft.EntityFrameworkCore;

namespace Mood2.Controllers
{
    //[Authorize]
    public class MoodyController : Controller
    {
        public MoodyController(ApplicationDbContext context)
        {
            _context = context;
        }


        const string subscriptionKey = "5c7133efeece4731b6e6662bd6ff2278";
        const string uriBase = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect";
        private ApplicationDbContext _context;




        public IActionResult SetupDatabase()
        {
            _context.EmotionData.Add(new EmotionData { Name = "anger" });
            _context.EmotionData.Add(new EmotionData { Name = "glad" });
            _context.EmotionData.Add(new EmotionData { Name = "glad" });
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Historik()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult ReturnEmotionAndPlaylist(string emotion)
        {
            PlaylistViewModel playlist = GetPlaylistByEmotion(emotion);

            return View(emotion, playlist);
        }

        static async Task<string> MakeAnalysisRequest(string pic)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            string uri = uriBase + "?" + requestParameters;

            HttpResponseMessage response;

            byte[] byteData = GetImageAsByteArray(pic);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();

                return contentString;
            }
        }

        static byte[] GetImageAsByteArray(string pic)
        {
            using (FileStream fileStream =
                new FileStream(pic, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        //gör metod som visar historik för inloggade användare
        [HttpGet]
        public IActionResult ShowHistory()
        {
            return View();

        }

        [HttpPost("UploadPic")]
        public async Task<IActionResult> PostPic(string pic)
        {
            if (pic == null)
            {
                return NoContent();
            }
            string replaced = pic.Substring(22);
            string filePath = Path.GetTempFileName();
            byte[] bytes = Convert.FromBase64String(replaced);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))

            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(replaced);

                    bw.Write(data);

                    bw.Close();
                }

            }
            var result = await MakeAnalysisRequest(filePath);
            string emotionResult = ConvertToEmotion(result);
            PlaylistViewModel playlist = GetPlaylistByEmotion(emotionResult);
            //PlaylistViewModel playlist = LinkPlaylistDependingOnEmotion(emotionResult);
            return View(emotionResult, playlist);
        }

        private PlaylistViewModel GetPlaylistByEmotion(string emotionResult)
        {
            var listOfPlaylists = new List<string>();
            var ThreePlaylists = new PlaylistViewModel();

            foreach (var item in _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == emotionResult))
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

        [AllowAnonymous]
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {



            if (file == null)
            {
                return NoContent();
            }
            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var result = await MakeAnalysisRequest(filePath);

            string emotionResult = ConvertToEmotion(result);
            PlaylistViewModel playlist = GetPlaylistByEmotion(emotionResult);
            return View(emotionResult, playlist);

        }

        [AllowAnonymous]
        public string ConvertToEmotion(string print)
        {
            var emotions = JsonConvert.DeserializeObject<List<Class1>>(print);

            Models.FaceApiData.Emotion AllEmotion = emotions[0].faceAttributes.emotion;

            var list = new List<EmotionsFromApi>
            {
                new  EmotionsFromApi
                {
                    EmotionName = "anger",
                    Value = AllEmotion.anger
                },
                new  EmotionsFromApi
                {
                    EmotionName = "contempt",
                    Value = AllEmotion.contempt
                },
                new  EmotionsFromApi
                {
                    EmotionName = "happiness",
                    Value = AllEmotion.happiness
                },
                new  EmotionsFromApi
                {
                    EmotionName = "fear",
                    Value = AllEmotion.fear
                },
                new  EmotionsFromApi
                {
                    EmotionName = "sadness",
                    Value = AllEmotion.sadness
                },
                new  EmotionsFromApi
                {
                    EmotionName = "surprise",
                    Value = AllEmotion.surprise
                },
                new EmotionsFromApi
                {
                    EmotionName = "neutral",
                    Value = AllEmotion.neutral
                },
                new  EmotionsFromApi
                {
                    EmotionName = "disgust",
                    Value = AllEmotion.disgust
                },
            };

            var primaryEmotion = list.OrderByDescending(x => x.Value).FirstOrDefault();
            string emotionResult = primaryEmotion.EmotionName;
            return emotionResult;


        }

        //[AllowAnonymous]
        //public PlaylistViewModel LinkPlaylistDependingOnEmotion(string emotionResult)
        //{
        //    emotionResult = emotionResult.ToLower();

        //    if (!new[] { "anger", "contempt" }.Contains(emotionResult))
        //    {
        //        throw new ArgumentException("Ogiltig emotion");
        //    }

            //    PlaylistViewModel result = new PlaylistViewModel();

            //    if (emotionResult == "anger" || emotionResult == "contempt" || emotionResult == "disgust")
            //    {
            //        result.Playlist1 = $"https://open.spotify.com/embed/user/artkul/playlist/0ybhZEyc8RrHsVDFt9x5CI";
            //        result.Playlist2 = $"https://open.spotify.com/embed/user/1239561108/playlist/29EOIjr2saw00KxpYdYSQM";
            //        result.Playlist3 = $"https://open.spotify.com/embed/user/dvaughan2021/playlist/5Am1VHtu0oJAc5omSVHvat";
            //        return result;
            //    }
            //    else if (emotionResult == "happiness")
            //    {
            //        result.Playlist1 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXdPec7aLTmlC";
            //        result.Playlist2 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXdPec7aLTmlC";
            //        result.Playlist3 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXdPec7aLTmlC";
            //    }
            //    else if (emotionResult == "fear")
            //    {
            //        result.Playlist1 = $"https://open.spotify.com/embed/show/5XhS5WBxLYgN3S9KhEyrrF";
            //        result.Playlist2 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX6SpcerLn1dx";
            //        result.Playlist3 = $"https://open.spotify.com/embed/user/warnermusicus/playlist/59njg5yJwvLH2vAuaZdAZD";
            //        return result;


            //    }
            //    else if (emotionResult == "sadness")
            //    {
            //        result.Playlist1 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX3YSRoSdA634";
            //        result.Playlist2 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX7qK8ma5wgG1";
            //        result.Playlist3 = $"https://open.spotify.com/embed/user/funnybunny000000/playlist/4EoPt05ztUjVaujcWbUL2Z";
            //        return result;


            //    }
            //    else if (emotionResult == "surprise")
            //    {
            //        result.Playlist1 = $"https://open.spotify.com/embed/user/ofinns/playlist/61CPcnHmTVMloD399c76et";
            //        result.Playlist2 = $"https://open.spotify.com/embed/user/juandurfelworld/playlist/1SUu5S4mKpyOEeuImxGM64";
            //        result.Playlist3 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWSEMER0I7qzl";
            //        return result;


            //    }
            //    else if (emotionResult == "neutral")
            //    {
            //        result.Playlist1 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXbITWG1ZJKYt";
            //        result.Playlist2 = $"https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWTkxQvqMy4WW";
            //        result.Playlist3 = $"https://open.spotify.com/embed/user/foilism/playlist/37qanRa2o6oa2l0TkMNdnD";
            //        return result;


            //    }

            //    return result;

            //}
        
    }
}

