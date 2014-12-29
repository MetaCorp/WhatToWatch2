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
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour UserControlFlmPreview.xaml
    /// </summary>
    public partial class UserControlFlmPreview : UserControl
    {
        Film film;
        Storyboard onLoaded;
        
        public UserControlFlmPreview()
        {
            InitializeComponent();

            onLoaded = (Storyboard)this.Resources["OnLoaded"];
        }

        public void Init(Film film)
        {
            this.film = film;

            this.labelTitle.Content = film.Title;
            this.labelYear.Content = film.Year;
            this.textBlockSyn.Text = film.Plot;

            if (film.Poster != "N/A")
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(film.Poster, UriKind.Absolute);
                img.EndInit();
                this.imagePoster.Source = img;
            }

            onLoaded.Begin(this);
        }

        private void buttonLibrary_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
