using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace UTO.ViewModels
{
    public class DataContainer
    {
        public static string Browser { get; set; } = "ie";
        private static ObservableCollection<Url> list = new ObservableCollection<Url>
            {
            }; 


        public static ObservableCollection<Url> GetUrlColl()
        {
            return list;
        }

        public static string[] GetUrlArray()
        {
            string[] arr = new string[list.Count];
            int i = 0;
            foreach (var item in list)
            {
                arr[i] = item.Name;
                ++i;
            }

            return arr;
        }

        public static void WriteSettings()
        {
            var dir = Directory.GetCurrentDirectory();
            Console.WriteLine("CurrentDirectory: " + dir);
            List<string> tmp = new List<string>();
            foreach (var urlObj in GetUrlColl())
            {
                tmp.Add(urlObj.Name);
            }
            tmp.Add("Browser " + Browser);
            File.WriteAllLines(dir + @"\settings.unt", tmp.ToArray());
        }

        public static void ReadSettings()
        {
            var dir = Directory.GetCurrentDirectory();
            if (!File.Exists(dir + @"\settings.unt"))
            {
                return;
            }
            foreach (var line in File.ReadLines(dir + @"\settings.unt"))
            {
                if (line.StartsWith("Browser"))
                {
                    Browser = line.Substring(8);
                }
                else
                {
                    list.Add(new Url {Name= line});
                }

            }
        }
    }
}