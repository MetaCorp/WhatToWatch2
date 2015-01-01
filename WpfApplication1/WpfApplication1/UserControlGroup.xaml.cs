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
    /// Logique d'interaction pour UserControlGroup.xaml
    /// </summary>
    public partial class UserControlGroup : UserControl
    {
        List<Film> films;
        Storyboard onLoaded, onHide;

        public UserControlGroup()
        {
            InitializeComponent();

            onLoaded = (Storyboard)this.Resources["OnLoaded"];
            onHide = (Storyboard)this.Resources["OnHide"];
        }

        public void Init(String title, List<Film> films, UserControlFlmPreview preview)
        {
            panel.Children.Clear();

            this.films = films;
            this.buttonTitle.Content = title + " >";

            for (int i = 0; i < films.Count; i++)
            {
                UserControlFilm userControlFilm = new UserControlFilm();
                userControlFilm.Height = 500;
                userControlFilm.Init(films[i], title, preview);

                panel.Children.Add(userControlFilm);
            }

            onLoaded.Begin(this);
        }

        private void buttonLibrary_Click(object sender, RoutedEventArgs e)
        {
            onHide.Begin(this);
        }
    }
}
