using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum SortBy
        {
            Genre,
            Year,
            Director,
            Actor
        }

        OMDbAPI api;
        Parser parser;

        //Dictionary<String, List<Film>> filmsByGenre, filmsByYear, filmsByDirector, filmsByActor;
        Dictionary<SortBy, Dictionary<String, List<Film>>> filmsBy;
        SortBy sortBy;
        public MainWindow()
        {
            GlobalConfig.Init();
            GlobalConfig.Directories = new List<String>() { @"F:\Videos\", @"C:\Users\leopo_000\Videos\" };

            InitializeComponent(); 
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.WindowState = System.Windows.WindowState.Maximized;

            radioButtonGenre.IsChecked = true;

            api = new OMDbAPI();
            parser = new Parser();

            List<FileInfo> filmsInfo = new List<FileInfo>();

            foreach (String path in GlobalConfig.Directories)
            {
                List<FileInfo> infos = ListDirectory(path);

                if (infos != null)
                    filmsInfo.AddRange(infos);
            }

            LoadFilms(filmsInfo);
            GlobalConfig.SortData();//Sort for display
            //RefreshFilmsFromApi();
            filmsBy = InitFilmsBy();// IMPORTANT

            FillLibraryPanel(sortBy);

            List<UserControlGroupLine> groupLines = new List<UserControlGroupLine>();

            userControlGroupLineToFinish.Init("To finish", Films.GetFilmToFinish(), userControlFilmPreview);
            groupLines.Add(userControlGroupLineToFinish);

            userControlGroupLineToWatch.Init("To watch", new List<Film>(), userControlFilmPreview);
            groupLines.Add(userControlGroupLineToWatch);

            userControlGroupLineRecentlyWatch.Init("Recently Watch", Films.GetFilmRecentlyWatch(), userControlFilmPreview);
            groupLines.Add(userControlGroupLineRecentlyWatch);

            userControlGroupLineRecentlyAdded.Init("Recently added", Films.GetFilmRecentlyAdded(), userControlFilmPreview);
            groupLines.Add(userControlGroupLineRecentlyAdded);

            userControlGroupLineLocal.Init("Local", Films.GetFilms(), userControlFilmPreview);
            groupLines.Add(userControlGroupLineLocal);

            foreach (UserControlGroupLine groupLine in groupLines)
                if (groupLine.IsEmpty())
                    panelHome.Children.Remove(groupLine);
        }

        private Dictionary<SortBy, Dictionary<String, List<Film>>> InitFilmsBy()
        {
            Dictionary<SortBy, Dictionary<String, List<Film>>> filmsByAux = new Dictionary<SortBy,Dictionary<string,List<Film>>>();

            Dictionary<String, List<Film>> filmsByGenre = new Dictionary<string,List<Film>>();
            Dictionary<String, List<Film>> filmsByYear = new Dictionary<string,List<Film>>();
            Dictionary<String, List<Film>> filmsByDirector = new Dictionary<string, List<Film>>();
            Dictionary<String, List<Film>> filmsByActor = new Dictionary<string, List<Film>>();
            
            // TO DO : classify by nb of film

            foreach (String genre in GlobalConfig.Genres)
                filmsByGenre.Add(genre, Films.GetFilmByGenre(genre));
            foreach (String year in GlobalConfig.Years)
                filmsByYear.Add(year, Films.GetFilmByYear(year));
            foreach (String director in GlobalConfig.Directors)
                filmsByDirector.Add(director, Films.GetFilmByDirector(director));
            foreach (String actor in GlobalConfig.Actors)
                filmsByActor.Add(actor, Films.GetFilmByActor(actor));


            filmsByActor = filmsByActor.OrderByDescending(kvp => kvp.Value.Count).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            filmsByDirector = filmsByDirector.OrderByDescending(kvp => kvp.Value.Count).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            filmsByAux.Add(SortBy.Genre, filmsByGenre);
            filmsByAux.Add(SortBy.Year, filmsByYear);
            filmsByAux.Add(SortBy.Director, filmsByDirector);
            filmsByAux.Add(SortBy.Actor, filmsByActor);

            return filmsByAux;
        }

        private void FillLibraryPanel(SortBy sortBy)
        {
            if (filmsBy == null) return;

            panelGenre.Children.Clear();

            foreach (KeyValuePair<String, List<Film>> entry in filmsBy[sortBy])
            {
                UserControlGroupBox userControlGroupBox = new UserControlGroupBox();
                userControlGroupBox.Init(entry.Key, entry.Value, userControlGroup, userControlFilmPreview);

                panelGenre.Children.Add(userControlGroupBox);
            }
        }

        private void LoadFilms(List<FileInfo> filmsInfo)
        {
            Films.DeserializeFilms();

            foreach (FileInfo filmInfo in filmsInfo)
                if (!Films.BansContainsPath(filmInfo.FullName))
                {
                    Film filmFound = Films.FindPath(filmInfo.FullName);

                    if (filmFound == null)
                    {
                        String title = parser.ExtractTitle(filmInfo.Name);

                        Film film = GetFilmFromApi(title);

                        if (film != null)
                        {
                            film.Init();

                            Film filmFound2 = Films.GetFilmByTitle(film.Title);

                            if (filmFound2 == null)
                            {
                                Films.AddFilm(film);
                                film.Paths.Add(filmInfo.FullName);
                            }// Film doublon
                            else
                            {
                                filmFound2.Paths.Add(filmInfo.FullName);
                                Films.AddBanPath(filmInfo.FullName);
                            }
                        }
                        else
                            Films.AddBanPath(filmInfo.FullName);
                    }
                }
        }

        private Film GetFilmFromApi(String title)
        {
            if (title == null) return null;

            Film film = api.Search(title);

            // TODO : Retry api with translated title

            if (film == null || film.imdbRating == "N/A" || Convert.ToInt32(film.imdbVotes.Replace(",", "")) < 1000)
                return null;

            film.DateAdded = DateTime.Now;

            return film;
        }

        private void RefreshFilmsFromApi()
        {
            List<Film> auxs = new List<Film>();
            foreach(Film film in Films.GetFilms())
            {
                Film aux = GetFilmFromApi(film.Title);// probleme accents

                if (aux == null)
                {
                    auxs.Add(film);
                    return;
                }

                aux.Init();
                aux.Paths = film.Paths;
                aux.ToWatch = film.ToWatch;
                aux.DateAdded = film.DateAdded;
                aux.DateWatched = film.DateWatched;
                auxs.Add(aux);
            }

            Films.Refresh(auxs);
        }

        private List<FileInfo> ListDirectory(string path)
        {
            if (!Directory.Exists(path)) return null;

            List<FileInfo> filmsInfo = new List<FileInfo>();

            Console.WriteLine("=== Listing Directory === ");

            foreach (string file in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".avi") || s.EndsWith(".mp4") || s.EndsWith(".mkv")))
                filmsInfo.Add(new FileInfo(file));

            Console.WriteLine("=== Done (" + filmsInfo.Count + ") ===");

            return filmsInfo;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Films.SerializeFilms();
        }

        // TODO : A regrouper
        private void radioButtonYear_Checked(object sender, RoutedEventArgs e)
        {
            sortBy = SortBy.Year;
            FillLibraryPanel(sortBy);
        }

        private void radioButtonGenre_Checked(object sender, RoutedEventArgs e)
        {
            sortBy = SortBy.Genre;
            FillLibraryPanel(sortBy);
        }

        private void radioButtonActor_Checked(object sender, RoutedEventArgs e)
        {
            sortBy = SortBy.Actor;
            FillLibraryPanel(sortBy);
        }

        private void radioButtonDirector_Checked(object sender, RoutedEventArgs e)
        {
            sortBy = SortBy.Director;
            FillLibraryPanel(sortBy);
        }
    }
}
