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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour UserControlFilm.xaml
    /// </summary>
    public partial class UserControlFilm : UserControl
    {
        public static Double offset = 10;
        public static Thickness StaticMargin { get { return new Thickness(offset); } set { StaticMargin = value; } }
        public static Thickness NegativStaticMargin { get { return new Thickness(-offset); } set { NegativStaticMargin = value; } }
        public Double WidthHover { get { return this.Width + 2 * (this.Margin.Left + this.Margin.Right); } }
        public Double MyWidth { get { return this.Width; }}

        public Double HeightHover { get { return this.Height + 2 * (this.Margin.Top + this.Margin.Bottom); } }
        public Double MyHeight { get { return this.Height; } }


        Film film;
        UserControlFlmPreview preview;

        public UserControlFilm()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Init(Film film, UserControlFlmPreview preview)
        {
            this.film = film;
            this.Width = this.Height * 2 / 3;
            this.preview = preview;

            this.labelTitle.Content = film.Title;

            if (film.Poster != "N/A")
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(film.Poster, UriKind.Absolute);
                img.EndInit();
                this.imagePoster.Source = img;
            }

            this.labelRate.Content = film.imdbRating;
            this.labelGenre.Content = film.Genre;
            this.labelYear.Content = film.Year;

        }

        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonTrailer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonWatch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            preview.Init(film);
            preview.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
