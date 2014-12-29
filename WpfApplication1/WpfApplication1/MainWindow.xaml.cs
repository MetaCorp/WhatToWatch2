﻿using System;
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
        OMDbAPI api;
        Parser parser;

        Dictionary<String, List<Film>> filmsByGenre;
        public MainWindow()
        {
            GlobalConfig.Init();
            GlobalConfig.Directories = new List<String>() { @"F:\Videos\", @"C:\Users\leopo_000\Videos\" };

            InitializeComponent(); 
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.WindowState = System.Windows.WindowState.Maximized;

            filmsByGenre = new Dictionary<string, List<Film>>();

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
            //RefreshFilmsFromApi();

            foreach (String genre in GlobalConfig.Genres)
            {
                UserControlGroupBox userControlGroupBox = new UserControlGroupBox();
                List<Film> filmsGenre = Films.GetFilmByGenre(genre);
                userControlGroupBox.Init(genre, filmsGenre, userControlGroup, userControlFilmPreview);
                //userControlGroupBox.labelTitle.Click += labelTitleGroupBox_Click;

                filmsByGenre.Add(genre, filmsGenre);

                panelGenre.Children.Add(userControlGroupBox);
            }

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
    }
}