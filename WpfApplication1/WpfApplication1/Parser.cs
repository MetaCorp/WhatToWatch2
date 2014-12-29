using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class Parser
    {
        static List<String> banWords = new List<String>() { "TS", "DivX", "sub", "SUB", "Part", "Fr", "Version", "dvd", "by", "BY", "By", "BDR", "cd", "VF", "vid", "vf", "fr", "TV", "UNCENSORED", "avi", "french", "French", "FRENCH", "DVD", "FR" };

        private bool CheckBanWords(String title)
        {
            if (title.Length == 4 && (title.Substring(0, 2) == "19" || title.Substring(0, 2) == "20"))//year
                return true;

            foreach (String word in banWords)
                if (title.Contains(word))
                    return true;

            return false;
        }

        private string RemoveFromto(String str, char sep1, char sep2)
        {
            int pos1 = str.IndexOf(sep1);
            int pos2 = str.LastIndexOf(sep2);

            if (pos1 == -1 || pos2 == -1)
                return str;

            string title = "";

            if (pos1 > 0)
                title += str.Substring(0, pos1);

            if (pos2 != str.Length)
                title += str.Substring(pos2 + 1);

            return title;
        }

        public string ExtractTitle(String name)
        {
            string title = name;
            title = title.Substring(0, title.LastIndexOf('.'));// Removes ext

            title = RemoveFromto(title, '(', ')');
            title = RemoveFromto(title, '[', ']');

            title = title.Replace("II", "2").Replace("III", "3").Replace("IIII", "4");

            String[] titles = title.Split(new char[4] { '-', '.', '_', ' ' });

            title = "";
            for (int i = 0; i < titles.Length && !CheckBanWords(titles[i]); i++)
                if (titles[i] != "")
                    title += titles[i] + " ";

            if (title == "")
                return null;

            title = title.Substring(0, title.Length - 1);

            return title;
        }
    }
}
