using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WpfApplication1
{
    public static class Films
    {
        static List<Film> films;
        static List<String> filmsBan;
        static int nbDayRecent = 7;

        public static void DeserializeFilms()
        {
            try
            {
                films = JsonConvert.DeserializeObject<List<Film>>(File.ReadAllText("films.json"));
            }
            catch
            {
                films = new List<Film>();
            }

            try
            {
                filmsBan = JsonConvert.DeserializeObject<List<String>>(File.ReadAllText("filmsBan.json"));
            }
            catch
            {
                filmsBan = new List<String>();
            }

            foreach (Film film in films)
            {
                GlobalConfig.AddGenres(film.Genres);
                GlobalConfig.AddDirectors(film.Directors);
                GlobalConfig.AddActors(film.ActorsList);
            }
        }

        public static void SerializeFilms()
        {
            using (StreamWriter sw = new StreamWriter("films.json"))
                sw.Write(JsonConvert.SerializeObject(films));

            using (StreamWriter sw = new StreamWriter("filmsBan.json"))
                sw.Write(JsonConvert.SerializeObject(filmsBan));
        }

        public static void Refresh(List<Film> auxs)
        {
            films = auxs;
        }

        public static List<Film> GetFilms()
        {
            return films;
        }

        public static void AddFilm(Film film)
        {
            films.Add(film);
            GlobalConfig.AddGenres(film.Genres);
            GlobalConfig.AddDirectors(film.Directors);
            GlobalConfig.AddActors(film.ActorsList);
        }

        public static void AddBanPath(String path)
        {
            filmsBan.Add(path);
        }

        public static void AddPath(Film film, string path)
        {
            film.Paths.Add(path);
        }

        public static List<Film> GetFilmByGenre(string genre)
        {
            return films.FindAll(film => film.Genres.Contains(genre));
        }
        public static List<Film> GetFilmByGenre(string genre, List<Film> films)
        {
            return films.FindAll(film => film.Genres.Contains(genre));
        }

        public static List<Film> GetFilmByYear(int year)
        {
            return films.FindAll(film => film.YearInt == year);
        }
        public static List<Film> GetFilmByYear(int year, List<Film> films)
        {
            return films.FindAll(film => film.YearInt == year);
        }

        public static List<Film> GetFilmByDirector(string director)
        {
            return films.FindAll(film => film.Directors.Contains(director));
        }
        public static List<Film> GetFilmByDirector(string director, List<Film> films)
        {
            return films.FindAll(film => film.Directors.Contains(director));
        }

        public static List<Film> GetFilmByActor(string actor)
        {
            return films.FindAll(film => film.ActorsList.Contains(actor));
        }
        public static List<Film> GetFilmByActor(string actor, List<Film> films)
        {
            return films.FindAll(film => film.ActorsList.Contains(actor));
        }

        public static List<Film> GetFilmToFinish()
        {
            return films.FindAll(film => film.CurrentTime != TimeSpan.Zero);
        }
        public static List<Film> GetFilmToFinish(List<Film> films)
        {
            return films.FindAll(film => film.CurrentTime != null);
        }

        public static List<Film> GetFilmRecentlyWatch()
        {
            return films.FindAll(film => film.DateWatched != null && DateTime.Now.Subtract(film.DateWatched).Days <= nbDayRecent);
        }
        public static List<Film> GetFilmRecentlyWatch(List<Film> films)
        {
            return films.FindAll(film => film.DateWatched != null && DateTime.Now.Subtract(film.DateWatched).Days <= nbDayRecent);
        }

        public static List<Film> GetFilmToWatch()
        {
            return films.FindAll(film => film.ToWatch);
        }
        public static List<Film> GetFilmToWatch(List<Film> films)
        {
            return films.FindAll(film => film.ToWatch);
        }

        public static List<Film> GetFilmRecentlyAdded()
        {
            List<Film> aux = films.FindAll(film => DateTime.Now.Subtract(film.DateAdded).Days <= nbDayRecent);
            aux.Sort((f1, f2) => f2.DateAdded.CompareTo(f1.DateAdded));
            return aux;
        }
        public static List<Film> GetFilmRecentlyAdded(List<Film> films)
        {
            List<Film> aux = films.FindAll(film => DateTime.Now.Subtract(film.DateAdded).Days <= nbDayRecent);
            aux.Sort((f1, f2) => f2.DateAdded.CompareTo(f1.DateAdded));
            return aux;
        }

        public static List<Film> GetFilmUnSeen()
        {
            return films.FindAll(film => film.CurrentTime == null);
        }
        public static List<Film> GetFilmUnSeen(List<Film> films)
        {
            return films.FindAll(film => film.CurrentTime == null);
        }

        public static List<Film> GetFilmBySearchTitle(string title)
        {
            return films.FindAll(film => film.Title.Contains(title));
        }
        public static List<Film> GetFilmBySearchTitle(string title, List<Film> films)
        {
            return films.FindAll(film => film.Title.Contains(title));
        }

        public static List<Film> GetFilmByAlpha(char c)
        {
            return films.FindAll(film => film.Title[0] == c);
        }
        public static List<Film> GetFilmByAlpha(char c, List<Film> films)
        {
            return films.FindAll(film => film.Title[0] == c);
        }

        public static Film GetFilmByTitle(String title)
        {
            return films.Find(film => film.Title == title);
        }

        public static Film FindPath(String path)
        {
            return films.Find(film => film.Paths.Contains(path));
        }

        public static bool BansContainsPath(String path)
        {
            return filmsBan.Contains(path);
        }

        public static bool Contains(Film film)
        {
            return films.Contains(film);
        }
    }
}
