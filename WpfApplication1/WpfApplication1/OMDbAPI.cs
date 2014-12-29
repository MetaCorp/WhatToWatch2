using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;

namespace WpfApplication1
{
    class OMDbAPI
    {
        public WebClient client { get; private set; }

        public OMDbAPI()// to fix: double search?
        {
            client = new WebClient();
        }

        public Film Search(string title)
        {
            Stopwatch watch = new Stopwatch();
            Console.Write("====== API is searching for " + title + " \t");
            watch.Start();

            string uri = "http://www.omdbapi.com/?t=" + title + "&plot=full&r=json";

            string res = client.DownloadString(uri);
            Film film = JsonConvert.DeserializeObject<Film>(res);

            watch.Stop();
            float time = watch.ElapsedMilliseconds;
            Console.WriteLine(time / 1000 + "" + time % 1000);

            return film.Response == "True" ? film : null;
        }
    }
}
