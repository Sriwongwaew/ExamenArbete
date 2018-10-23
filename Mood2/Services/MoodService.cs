using Mood2.Data;
using Mood2.Models;
using Mood2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mood2.Services
{
    public class MoodService
    {

        private readonly ApplicationDbContext _context;

        public MoodService(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public void SetUpDatabaseIfItsNotAlreadySetup()
        {
            if (!_context.EmotionData.Any())
            {
                SetUpDatabase();
            }
        }
        public void SetUpDatabase()
        {
            _context.EmotionData.AddRange(new EmotionData
            {
                Name = "anger"
            },
            new EmotionData
            {
                Name = "happiness"
            }, new EmotionData
            {
                Name = "surprise"
            }, new EmotionData
            {
                Name = "sadness"
            }, new EmotionData
            {
                Name = "fear"
            }, new EmotionData
            {
                Name = "neutral"
            });


            _context.SaveChanges();
            //-----------------------------------------------------------------------


            var angerID = _context.EmotionData.Single(x => x.Name == "anger");

            _context.Playlist.AddRange(new Playlist
            {
                EmotionDataId = angerID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/artkul/playlist/0ybhZEyc8RrHsVDFt9x5CI"
            },
            new Playlist
            {
                EmotionDataId = angerID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/1239561108/playlist/29EOIjr2saw00KxpYdYSQM"
            },
            new Playlist
            {
                EmotionDataId = angerID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/dvaughan2021/playlist/5Am1VHtu0oJAc5omSVHvat"
            },
             new Playlist //-------
                 {
                 EmotionDataId = angerID.Id,
                 PlaylistLink = "https://open.spotify.com/user/cosmoph/playlist/1AcFWoqI3Pug3wmy59mCb0?si=1kShR6GjT4uYk6pxpxEcOw"
             },
              new Playlist
              {
                  EmotionDataId = angerID.Id,
                  PlaylistLink = "https://open.spotify.com/user/jewlgurl/playlist/7L08IETH8EQmm7k4r8rivb?si=RUQvLCwSTqiKw9eaRj4QwA"
              },
              new Playlist
              {
                  EmotionDataId = angerID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/5s7Sp5OZsw981I2OkQmyrz?si=oEz6cfkUTIeYAqNUiWMyRg"
              },
              new Playlist
              {
                  EmotionDataId = angerID.Id,
                  PlaylistLink = "https://open.spotify.com/user/vheist16/playlist/0jFTAWnKeif1jeycmfzntA?si=sMYW68SBRS2NljjAeaMoQg"
              },
              new Playlist
              {
                  EmotionDataId = angerID.Id,
                  PlaylistLink = "https://open.spotify.com/user/1222144685/playlist/2x1PpZv5jzhUGxzztJwaNi?si=ac5Kjf_6RCKw8Gdj-3tanw"
              },
              new Playlist
              {
                  EmotionDataId = angerID.Id,
                  PlaylistLink = "https://open.spotify.com/user/1222144685/playlist/2x1PpZv5jzhUGxzztJwaNi?si=YrQ6TC6IS3G2qQXVhUDbIA"
              },
               new Playlist
               {
                   EmotionDataId = angerID.Id,
                   PlaylistLink = "https://open.spotify.com/user/mdlewis22/playlist/48zs9ygC4jOvfn4sSt9RjB?si=m8Qg2fO9RPGJGAiJTsYD3Q"
               });
            //-----------------------------------------------------------------------


            var happyID = _context.EmotionData.Single(x => x.Name == "happiness");

            _context.Playlist.AddRange(new Playlist
            {
                EmotionDataId = happyID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXdPec7aLTmlC"
            },
            new Playlist
            {
                EmotionDataId = happyID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWVs8I62NcHks"
            },
            new Playlist
            {
                EmotionDataId = happyID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/dvaughan2021/playlist/5Am1VHtu0oJAc5omSVHvat"
            },
             new Playlist //-------
                 {
                 EmotionDataId = happyID.Id,
                 PlaylistLink = " "
             },
              new Playlist
              {
                  EmotionDataId = happyID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = happyID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = happyID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = happyID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = happyID.Id,
                  PlaylistLink = " "
              },
               new Playlist
               {
                   EmotionDataId = happyID.Id,
                   PlaylistLink = " "
               });
            //-----------------------------------------------------------------------

            var surpriseID = _context.EmotionData.Single(x => x.Name == "surprise");

            _context.Playlist.AddRange(new Playlist
            {
                EmotionDataId = surpriseID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/ofinns/playlist/61CPcnHmTVMloD399c76et"
            },
            new Playlist
            {
                EmotionDataId = surpriseID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/juandurfelworld/playlist/1SUu5S4mKpyOEeuImxGM64"
            },
            new Playlist
            {
                EmotionDataId = surpriseID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWSEMER0I7qzl"
            },
             new Playlist //-------
                 {
                 EmotionDataId = surpriseID.Id,
                 PlaylistLink = "https://open.spotify.com/user/126792456/playlist/0feDLyvWBdzOvewFnLM6Px?si=oGdFeumMQKCkgulTpcVsKQ"
             },
              new Playlist
              {
                  EmotionDataId = surpriseID.Id,
                  PlaylistLink = "https://open.spotify.com/user/officiallifeisstrange/playlist/1f5ZzLDTXHTDR8CYIEddpW?si=rXefv5a9SXq5VBpTxDRArw"
              },
              new Playlist
              {
                  EmotionDataId = surpriseID.Id,
                  PlaylistLink = "https://open.spotify.com/user/rocky-m/playlist/54pucq433rZsjpuK9GdbaD?si=w5VQfeqUSziPdJ8jUgIy5w"
              },
              new Playlist
              {
                  EmotionDataId = surpriseID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DWUraJYejk11q?si=FAIIuLeBSpKuc2sEA1tVyw"
              },
              new Playlist
              {
                  EmotionDataId = surpriseID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX3ZeFHRhhi7Y?si=_p25S9lQSIK3YnI9zcBJ2Q"
              },
              new Playlist
              {
                  EmotionDataId = surpriseID.Id,
                  PlaylistLink = "https://open.spotify.com/user/ofinns/playlist/1fNw33uLdD1tSc0MYk46bb?si=m5MNmCYmRRCDudpBJhrtBw"
              },
               new Playlist
               {
                   EmotionDataId = surpriseID.Id,
                   PlaylistLink = "https://open.spotify.com/user/128899670/playlist/5NtjgKz4doejP5HJtKXFcS?si=EDbQVHBmTcKDekm1BPzxrA"
               });


            //-----------------------------------------------------------------------

            var sadnessID = _context.EmotionData.Single(x => x.Name == "sadness");

            _context.Playlist.AddRange(new Playlist
            {
                EmotionDataId = sadnessID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX3YSRoSdA634"
            },
            new Playlist
            {
                EmotionDataId = sadnessID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX7qK8ma5wgG1"
            },
            new Playlist
            {
                EmotionDataId = sadnessID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/funnybunny000000/playlist/4EoPt05ztUjVaujcWbUL2Z"
            },
             new Playlist //-------
                 {
                 EmotionDataId = sadnessID.Id,
                 PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX2ViysbCzMHO?si=DaBuAgXlRhqjtxz3aHA4Lw"
             },
              new Playlist
              {
                  EmotionDataId = sadnessID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX4sWSpwq3LiO?si=AniopkLURw2Fk5kiU7C59Q"
              },
              new Playlist
              {
                  EmotionDataId = sadnessID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX7qK8ma5wgG1?si=JT1WvxumS9KxIEp_3vm6Cg"
              },
              new Playlist
              {
                  EmotionDataId = sadnessID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX4Umko6nOmN7?si=ocrJ-61fSi-ZEopGeh6Djw"
              },
              new Playlist
              {
                  EmotionDataId = sadnessID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DWVHi578arQLF?si=FLFh3GpUSMWttch7Vdcfpw"
              },
              new Playlist
              {
                  EmotionDataId = sadnessID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX0jgyAiPl8Af?si=nZJ1ClGSQPqp__TUwiPN_A"
              },
               new Playlist
               {
                   EmotionDataId = sadnessID.Id,
                   PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DXcTFqUWLeE6m?si=-vPuLhwqS3uUNKPEX2-8ag"
               });

            //--------------------------------------------------
            var fearID = _context.EmotionData.Single(x => x.Name == "fear");

            _context.Playlist.AddRange(new Playlist
            {
                EmotionDataId = fearID.Id,
                PlaylistLink = "https://open.spotify.com/embed/show/5XhS5WBxLYgN3S9KhEyrrF"
            },
            new Playlist
            {
                EmotionDataId = fearID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX6SpcerLn1dx"
            },
            new Playlist
            {
                EmotionDataId = fearID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/warnermusicus/playlist/59njg5yJwvLH2vAuaZdAZD"
            },
             new Playlist //-------
                 {
                 EmotionDataId = fearID.Id,
                 PlaylistLink = " "
             },
              new Playlist
              {
                  EmotionDataId = fearID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = fearID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = fearID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = fearID.Id,
                  PlaylistLink = " "
              },
              new Playlist
              {
                  EmotionDataId = fearID.Id,
                  PlaylistLink = " "
              },
               new Playlist
               {
                   EmotionDataId = fearID.Id,
                   PlaylistLink = " "
               });

            //--------------------------------------------------------------
            var neutralID = _context.EmotionData.Single(x => x.Name == "neutral");

            _context.Playlist.AddRange(new Playlist
            {
                EmotionDataId = neutralID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXbITWG1ZJKYt"
            },
            new Playlist
            {
                EmotionDataId = neutralID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWTkxQvqMy4WW"
            },
            new Playlist
            {
                EmotionDataId = neutralID.Id,
                PlaylistLink = "https://open.spotify.com/embed/user/foilism/playlist/37qanRa2o6oa2l0TkMNdnD"
            },
             new Playlist //-------
                 {
                 EmotionDataId = neutralID.Id,
                 PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX4WYpdgoIcn6?si=Dvsd5HsDSwGay9Cg8Lb9Gw"
             },
              new Playlist
              {
                  EmotionDataId = neutralID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DWVYZVgDjIR7c?si=bsa4-gDPTjmaJAOcMz9_Tg"
              },
              new Playlist
              {
                  EmotionDataId = neutralID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DXcBWIGoYBM5M?si=ZPbjmypOSg-IusRuJ_9KAg"
              },
              new Playlist
              {
                  EmotionDataId = neutralID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DXc4CrXgl8cum?si=uXpKr0wvS2-iYUHpyiJO9g"
              },
              new Playlist
              {
                  EmotionDataId = neutralID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DXcF6B6QPhFDv?si=VCFc1vVLRGWY7b9VU6-n4Q"
              },
              new Playlist
              {
                  EmotionDataId = neutralID.Id,
                  PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DXcF6B6QPhFDv?si=d5B4575kRdS6UOLi0UJ0Lg"
              },
               new Playlist
               {
                   EmotionDataId = neutralID.Id,
                   PlaylistLink = "https://open.spotify.com/user/spotify/playlist/37i9dQZF1DXaXB8fQg7xif?si=pc6zz6j4QhWyTAFPkkam4A"
               });
            _context.SaveChanges();
        }

    }


}
