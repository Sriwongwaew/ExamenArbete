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
                listOfPlaylists.Add(item.PlayListLink);
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


            var angerID = _context.EmotionData.Single(x => x.Name == "anger" || x.Name == "contempt" || x.Name == "disgust");

            _context.Playlist.AddRange(new Playlist
            {
                PlayListName = "Angry",
                EmotionDataId = angerID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/artkul/playlist/0ybhZEyc8RrHsVDFt9x5CI"
            },
            new Playlist
            {
                PlayListName = "Angry Classicals",
                EmotionDataId = angerID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/1239561108/playlist/29EOIjr2saw00KxpYdYSQM"
            },
            new Playlist
            {
                PlayListName = "Anger release",
                EmotionDataId = angerID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/dvaughan2021/playlist/5Am1VHtu0oJAc5omSVHvat"
            },
             new Playlist //-------
             {
                 PlayListName = "Songs To Listen To When You're Mad At Your Boyfriend",
                 EmotionDataId = angerID.Id,
                 PlayListLink = "https://open.spotify.com/embed/user/cosmoph/playlist/1AcFWoqI3Pug3wmy59mCb0"
             },
              new Playlist
              {
                  PlayListName = "ANGRY PLAYLIST",
                  EmotionDataId = angerID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/jewlgurl/playlist/7L08IETH8EQmm7k4r8rivb"
              },
              new Playlist
              {
                  PlayListName = "Rage Quit",
                  EmotionDataId = angerID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/5s7Sp5OZsw981I2OkQmyrz"
              },
              new Playlist
              {
                  PlayListName = "Angry Feminist",
                  EmotionDataId = angerID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/vheist16/playlist/0jFTAWnKeif1jeycmfzntA"
              },
              new Playlist
              {
                  PlayListName = "J-Rock/J-Metal/J-Punk/J-Pop/Anime/Japan",
                  EmotionDataId = angerID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/1222144685/playlist/2x1PpZv5jzhUGxzztJwaNi"
              },
              new Playlist
              {
                  PlayListName = "Angry workout",
                  EmotionDataId = angerID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/119988902/playlist/5qUWjT1fYzj9zwstkkOWjf"
              },
               new Playlist
               {
                   PlayListName = "Angry Women",
                   EmotionDataId = angerID.Id,
                   PlayListLink = "https://open.spotify.com/embed/user/mdlewis22/playlist/48zs9ygC4jOvfn4sSt9RjB"
               });
            //-----------------------------------------------------------------------


            var happyID = _context.EmotionData.Single(x => x.Name == "happiness");

            _context.Playlist.AddRange(new Playlist
            {
                PlayListName = "Happy Hits!",
                EmotionDataId = happyID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXdPec7aLTmlC"
            },
            new Playlist
            {
                PlayListName = "This Is Disney",
                EmotionDataId = happyID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWVs8I62NcHks"
            },
            new Playlist
            {
                PlayListName = "Anger release",
                EmotionDataId = happyID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/dvaughan2021/playlist/5Am1VHtu0oJAc5omSVHvat"
            },
             new Playlist //-------
             {
                 PlayListName = "Dance Party",
                 EmotionDataId = happyID.Id,
                 PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXaXB8fQg7xif"
             },
              new Playlist
              {
                  PlayListName = "Dance Classics",
                  EmotionDataId = happyID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX8a1tdzq5tbM"
              },
              new Playlist
              {
                  PlayListName = "Carnival",
                  EmotionDataId = happyID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX0rM1NjYKMJa"
              },
              new Playlist
              {
                  PlayListName = "Happy Folk",
                  EmotionDataId = happyID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWSkMjlBZAZ07"
              },
              new Playlist
              {
                  PlayListName = "Träna till 80-talet",
                  EmotionDataId = happyID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWYaLsh50zXN6"
              },
              new Playlist
              {
                  PlayListName = "Träna till 90-talet",
                  EmotionDataId = happyID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXcQFLaKHy42g"
              },
               new Playlist
               {
                   PlayListName = "All Out 70s",
                   EmotionDataId = happyID.Id,
                   PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWTJ7xPn4vNaz"
               });
            //-----------------------------------------------------------------------

            var surpriseID = _context.EmotionData.Single(x => x.Name == "surprise");

            _context.Playlist.AddRange(new Playlist
            {
                PlayListName = "Surprise",
                EmotionDataId = surpriseID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/ofinns/playlist/61CPcnHmTVMloD399c76et"
            },
            new Playlist
            {
                PlayListName = "Weird Playlist",
                EmotionDataId = surpriseID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/juandurfelworld/playlist/1SUu5S4mKpyOEeuImxGM64"
            },
            new Playlist
            {
                PlayListName = "The PMS Playlist",
                EmotionDataId = surpriseID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWSEMER0I7qzl"
            },
             new Playlist //-------
             {
                 PlayListName = "Twin Peaks: Isn't Too Dreamy",
                 EmotionDataId = surpriseID.Id,
                 PlayListLink = "https://open.spotify.com/embed/user/126792456/playlist/0feDLyvWBdzOvewFnLM6Px"
             },
              new Playlist
              {
                  PlayListName = "Life is Strange",
                  EmotionDataId = surpriseID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/officiallifeisstrange/playlist/1f5ZzLDTXHTDR8CYIEddpW"
              },
              new Playlist
              {
                  PlayListName = "Dubstep gym",
                  EmotionDataId = surpriseID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/rocky-m/playlist/54pucq433rZsjpuK9GdbaD"
              },
              new Playlist
              {
                  PlayListName = "Genre Glitch",
                  EmotionDataId = surpriseID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWUraJYejk11q"
              },
              new Playlist
              {
                  PlayListName = "Fantastic K-Workout",
                  EmotionDataId = surpriseID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX3ZeFHRhhi7Y"
              },
              new Playlist
              {
                  PlayListName = "En regnig natt i Paris",
                  EmotionDataId = surpriseID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/ofinns/playlist/1fNw33uLdD1tSc0MYk46bb"
              },
               new Playlist
               {
                   PlayListName = "Disney Hits",
                   EmotionDataId = surpriseID.Id,
                   PlayListLink = "https://open.spotify.com/embed/user/128899670/playlist/5NtjgKz4doejP5HJtKXFcS"
               });


            //-----------------------------------------------------------------------

            var sadnessID = _context.EmotionData.Single(x => x.Name == "sadness");

            _context.Playlist.AddRange(new Playlist
            {
                PlayListName = "Life Sucks",
                EmotionDataId = sadnessID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX3YSRoSdA634"
            },
            new Playlist
            {
                PlayListName = "Sad Songs",
                EmotionDataId = sadnessID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX7qK8ma5wgG1"
            },
            new Playlist
            {
                PlayListName = "Sad Songs :(",
                EmotionDataId = sadnessID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/funnybunny000000/playlist/4EoPt05ztUjVaujcWbUL2Z"
            },
             new Playlist //-------
             {
                 PlayListName = "Nashville Stripped",
                 EmotionDataId = sadnessID.Id,
                 PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX2ViysbCzMHO"
             },
              new Playlist
              {
                  PlayListName = "Peaceful Piano",
                  EmotionDataId = sadnessID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX4sWSpwq3LiO"
              },
              new Playlist
              {
                  PlayListName = "Floating in the Darkness",
                  EmotionDataId = sadnessID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/ofinns/playlist/13cJd30xNQV9anWRYlbi1d"
              },
              new Playlist
              {
                  PlayListName = "Lugnt & Skönt",
                  EmotionDataId = sadnessID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX4Umko6nOmN7"
              },
              new Playlist
              {
                  PlayListName = "Singer Songwriter Coffee Break",
                  EmotionDataId = sadnessID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWVHi578arQLF"
              },
              new Playlist
              {
                  PlayListName = "Peaceful Guitar",
                  EmotionDataId = sadnessID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX0jgyAiPl8Af"
              },
               new Playlist
               {
                   PlayListName = "Rofylld",
                   EmotionDataId = sadnessID.Id,
                   PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXcTFqUWLeE6m"
               });

            //--------------------------------------------------
            var fearID = _context.EmotionData.Single(x => x.Name == "fear");

            _context.Playlist.AddRange(new Playlist
            {
                PlayListName = "The NoSleep Podcast",
                EmotionDataId = fearID.Id,
                PlayListLink = "https://open.spotify.com/embed/show/5XhS5WBxLYgN3S9KhEyrrF"
            },
            new Playlist
            {
                PlayListName = "Halloween Monster Jams",
                EmotionDataId = fearID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX6SpcerLn1dx"
            },
            new Playlist
            {
                PlayListName = "Fearless Females",
                EmotionDataId = fearID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/warnermusicus/playlist/59njg5yJwvLH2vAuaZdAZD"
            },
             new Playlist //-------
             {
                 PlayListName = "J-Rock/J-Metal/J-Punk/J-pop/Anime/Japan",
                 EmotionDataId = fearID.Id,
                 PlayListLink = "https://open.spotify.com/embed/user/1222144685/playlist/2x1PpZv5jzhUGxzztJwaNi"
             },
              new Playlist
              {
                  PlayListName = "80's Popped!",
                  EmotionDataId = fearID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX82SvZY6fOWx"
              },
              new Playlist
              {
                  PlayListName = "Halloween/Disneyland",
                  EmotionDataId = fearID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/1284086214/playlist/2cfr9ecGedQM3WhxRWZtLE"
              },
              new Playlist
              {
                  PlayListName = "Classic Halloween Playlist",
                  EmotionDataId = fearID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/hauntedwisconsin.com/playlist/23NaNmH6LuCctSM6lplaZb"
              },
              new Playlist
              {
                  PlayListName = "Disney Halloween",
                  EmotionDataId = fearID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/128899670/playlist/2tvNusayRwIpqd55BA9y1T"
              },
              new Playlist
              {
                  PlayListName = "My Little Pony: The Movie",
                  EmotionDataId = fearID.Id,
                  PlayListLink = "https://open.spotify.com/embed/album/2kUJgoPA2iz9c2jzUr0y1x"
              },
               new Playlist
               {
                   PlayListName = "Creepypodden i P3",
                   EmotionDataId = fearID.Id,
                   PlayListLink = "https://open.spotify.com/embed/show/4CSrmtPagkWuNGy4JocfNB"
               });

            //--------------------------------------------------------------
            var neutralID = _context.EmotionData.Single(x => x.Name == "neutral");

            _context.Playlist.AddRange(new Playlist
            {
                PlayListName = "Jazz Classics",
                EmotionDataId = neutralID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXbITWG1ZJKYt"
            },
            new Playlist
            {
                PlayListName = "Chillin' on a Dirt Road",
                EmotionDataId = neutralID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWTkxQvqMy4WW"
            },
            new Playlist
            {
                PlayListName = "Space - [Ambient]",
                EmotionDataId = neutralID.Id,
                PlayListLink = "https://open.spotify.com/embed/user/foilism/playlist/37qanRa2o6oa2l0TkMNdnD"
            },
             new Playlist //-------
             {
                 PlayListName = "Chill Hits",
                 EmotionDataId = neutralID.Id,
                 PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX4WYpdgoIcn6"
             },
              new Playlist
              {
                  PlayListName = "Soft höst",
                  EmotionDataId = neutralID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DWVYZVgDjIR7c"
              },
              new Playlist
              {
                  PlayListName = "Today's Top Hits",
                  EmotionDataId = neutralID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXcBWIGoYBM5M"
              },
              new Playlist
              {
                  PlayListName = "Get Your Hits Together",
                  EmotionDataId = neutralID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXc4CrXgl8cum"
              },
              new Playlist
              {
                  PlayListName = "Rock This",
                  EmotionDataId = neutralID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXcF6B6QPhFDv"
              },
              new Playlist
              {
                  PlayListName = "Dansband: Favoriter",
                  EmotionDataId = neutralID.Id,
                  PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DX1a3nBJMXoti"
              },
               new Playlist
               {
                   PlayListName = "Dance Party",
                   EmotionDataId = neutralID.Id,
                   PlayListLink = "https://open.spotify.com/embed/user/spotify/playlist/37i9dQZF1DXaXB8fQg7xif"
               });
            _context.SaveChanges();
        }

    }


}
