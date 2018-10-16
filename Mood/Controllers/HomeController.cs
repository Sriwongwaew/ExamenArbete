﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mood.Models.FaceApiData;
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

namespace Mood.Controllers
{
    public class HomeController : Controller
    {
        const string subscriptionKey = "0f02fdf50aa34b43a890cc185515e46f";
        const string uriBase =
        "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";

        //string print = "";

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Mood");
        }

        static async Task<string> MakeAnalysisRequest(string pic)
        {
            HttpClient client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters. A third optional parameter is "details".
            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            // Assemble the URI for the REST API Call.
            string uri = uriBase + "?" + requestParameters;

            HttpResponseMessage response;

            // Request body. Posts a locally stored JPEG image.
            byte[] byteData = GetImageAsByteArray(pic);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json"
                // and "multipart/form-data".
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                response = await client.PostAsync(uri, content);

                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();

                // Display the JSON response.
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

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {

            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var print = await MakeAnalysisRequest(filePath);
            ConvertToEmotion(print);
            return Ok();
        }

        public void ConvertToEmotion(string print)
        {
            var emotions = JsonConvert.DeserializeObject<List<Class1>>(print);

            var AllEmotion = emotions[0].faceAttributes.emotion;


            //scores.FirstOrDefault(x => x.Value == emotions[0].scores.Values.Max()).Key;




        }


    }

}

