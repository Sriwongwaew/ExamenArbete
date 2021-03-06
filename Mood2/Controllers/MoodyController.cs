﻿using Microsoft.AspNetCore.Authorization;
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
        private ApplicationDbContext _context;


        public MoodyController(ApplicationDbContext context)
        {
            _context = context;
        }

    


        const string subscriptionKey = "5c7133efeece4731b6e6662bd6ff2278";
        const string uriBase = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect";


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

       
        public IActionResult ReturnEmotionAndPlaylist(string emotion)
        {
            try
            {
                PlaylistViewModel playlist = GetPlaylistByEmotion(emotion);

 
                SaveToHistory(emotion, playlist);

                if (emotion.ToLower() == "anger" || emotion.ToLower() == "disgust" || emotion.ToLower() == "contempt")
                    return View("anger2", playlist);

                return View(emotion, playlist);
            } catch (Exception ex)
            {
                return Ok(ex);
            }
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
        public IActionResult Historik()
        {
            var historyList = _context.History.Take(10).OrderByDescending(x => x.DateWhenPlayed).ToList();
            return View("Historik", historyList);
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
            SaveToHistory(emotionResult, playlist);
            return View(emotionResult, playlist);
        }

        private PlaylistViewModel GetPlaylistByEmotion(string emotionResult)
        {
            var listOfPlaylists = new List<Playlist>();
            var ThreePlaylists = new PlaylistViewModel();

            foreach (var item in _context.Playlist.Include(x => x.EmotionData).Where(x => x.EmotionData.Name == emotionResult))
            {
                var playlist = new Playlist();
                playlist.PlayListLink = item.PlayListLink;
                playlist.PlayListName = item.PlayListName;

                listOfPlaylists.Add(playlist);

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
            SaveToHistory(emotionResult, playlist);
            return View(emotionResult, playlist);

        }

        private void SaveToHistory(string emotionResult, PlaylistViewModel playlist)
        {
            _context.History.Add(new History
            {
                PlaylistLink = playlist.Playlist1.PlayListLink,
                PlaylistName = playlist.Playlist1.PlayListName,
                DateWhenPlayed = DateTime.Now,
                Emotion = emotionResult

            });
            _context.SaveChanges();
        }

        [AllowAnonymous]
        public string ConvertToEmotion(string print)
        {
            var emotions = JsonConvert.DeserializeObject<List<Class1>>(print);

            Emotion AllEmotion = emotions[0].faceAttributes.emotion;

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
            if (emotionResult == "disgust" || emotionResult == "contempt")
            {
                emotionResult = "anger";
            }
            return emotionResult;


        }
    }
}

