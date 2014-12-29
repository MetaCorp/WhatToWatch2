using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public static class User
    {
        static Random rnd = new Random();
        public static List<Film> OrderFilms(List<Film> films)
        {
            return films.OrderBy(film => rnd.Next()).ToList();
        }
    }
}
