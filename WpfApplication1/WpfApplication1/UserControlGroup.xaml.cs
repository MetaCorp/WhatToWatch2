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
    /// Logique d'interaction pour UserControlGroup.xaml
    /// </summary>
    public partial class UserControlGroup : UserControl
    {
        List<Film> films;
        public UserControlGroup()
        {
            InitializeComponent();
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
                userControlFilm.Init(films[i], preview);

                panel.Children.Add(userControlFilm);
            }
        }

        private void buttonLibrary_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
