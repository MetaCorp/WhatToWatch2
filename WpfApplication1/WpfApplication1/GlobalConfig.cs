using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public static class GlobalConfig
    {
        public static List<String> Genres;
        public static List<String> Actors;
        public static List<String> Directors;
        public static List<String> Directories;
        public static String VlcPath;
        public static List<String> Groups;

        public static void Init()
        {
            Genres = new List<String>();
            Actors = new List<String>();
            Directors = new List<String>();
        }

        public static void AddGenres(List<String> genres)
        {
            foreach (String genre in genres)
                if (!Genres.Contains(genre))
                    Genres.Add(genre);
        }

        public static void AddActors(List<String> actors)
        {
            foreach (String actor in actors)
                if (!Actors.Contains(actor))
                    Actors.Add(actor);
        }

        public static void AddDirectors(List<String> directors)
        {
            foreach (String director in directors)
                if (!Directors.Contains(director))
                    Directors.Add(director);
        }
    }
}
