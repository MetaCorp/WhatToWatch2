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
    /// Logique d'interaction pour UserControlGroupBox.xaml
    /// </summary>
    public partial class UserControlGroupBox : UserControl
    {
        public Double MyWidth { get { return MyHeight * 3 / 4;}}// userControlFirstFilm.Width + 2 * (userControlFirstFilm.Padding.Left + userControlFirstFilm.Padding.Right); } }
        public static Double MyHeight = 500;
        public String title;
        List<Film> films;
        UserControlGroup group;
        UserControlFlmPreview preview;
        Storyboard onHide;

        public UserControlGroupBox()
        {
            InitializeComponent();
            DataContext = this;

            onHide = (Storyboard)this.Resources["OnHide"];
        }

        public void Init(String title, List<Film> films, UserControlGroup group, UserControlFlmPreview preview)
        {
            this.labelTitle.Content = title + " >";
            this.films = User.OrderFilms(films);
            this.title = title;
            this.group = group;
            this.preview = preview;

            if (films.Count == 0)
                return;

            userControlFirstFilm.Init(this.films[0], preview);
            userControlFirstFilm.Height = MyHeight;
            this.Height = userControlFirstFilm.Height + content.Margin.Top + content.Margin.Bottom + userControlFirstFilm.Margin.Top + userControlFirstFilm.Margin.Bottom + 2;
            userControlFirstFilm.MouseDoubleClick += userControlFilm_MouseDoubleClick;
            
            for (int i = 1; i < films.Count && i < 7; i++)
            {
                UserControlFilm userControlFilm = new UserControlFilm();
                userControlFilm.Height = -(userControlFilm.Margin.Top + userControlFilm.Margin.Bottom) / 2 + userControlFirstFilm.Height / 2;
                userControlFilm.Init(this.films[i], preview);

                userControlFilm.MouseDoubleClick += userControlFilm_MouseDoubleClick;

                panel.Children.Add(userControlFilm);
            }
        }

        void userControlFilm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //onHide.Begin(this);
        }

        private void labelTitle_Click(object sender, RoutedEventArgs e)
        {
            group.Init(title, films, preview);
            group.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
