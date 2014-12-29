using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Film
    {
        public String Title;
        public List<String> Genres;
        public List<String> Directors;
        public List<String> ActorsList;
        public int YearInt;
        public TimeSpan CurrentTime;
        public DateTime DateAdded;
        public DateTime DateWatched;
        public bool ToWatch;
        public List<String> Paths;

        public String Response;
        public String imdbRating, imdbVotes;
        public String Genre;
        public String Director;
        public String Actors;
        public String Poster;
        public String Year;
        public String Plot;

        public void Init()
        {
            Paths = new List<String>();
            ToWatch = false;

            Genres = Genre.Split(new string[1] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Directors = Director.Split(new string[1] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ActorsList = Actors.Split(new string[1] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Int32.TryParse(Year, out YearInt);
        }
    }
}
