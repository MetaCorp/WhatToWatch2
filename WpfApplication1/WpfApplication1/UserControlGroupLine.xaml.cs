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
    /// Logique d'interaction pour UserControlGroupLine.xaml
    /// </summary>
    public partial class UserControlGroupLine : UserControl
    {
        List<Film> films;
        public UserControlGroupLine()
        {
            InitializeComponent();
        }

        public void Init(String title, List<Film> films, UserControlFlmPreview preview)
        {
            this.films = films;
            this.labelTitle.Content = title + " >";

            for (int i = 0; i < films.Count && i < 10; i++)
            {
                UserControlFilm userControlFilm = new UserControlFilm();
                userControlFilm.Height = 350;
                userControlFilm.Init(films[i], preview);

                panel.Children.Add(userControlFilm);
            }
        }

        public bool IsEmpty()
        {
            return films.Count == 0;
        }
    }
}
