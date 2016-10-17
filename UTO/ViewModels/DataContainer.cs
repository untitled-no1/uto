using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace UTO.ViewModels
{
    public class DataContainer
    {
        private static ObservableCollection<Url> list = new ObservableCollection<Url>
            {
                new Url {Name = "www.untitled-no1.at"},
                new Url {Name = "www.facebook.com"},
                new Url {Name = "www.digitaltrends.com"},
                new Url {Name = "www.microsoft.com"}
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
    }
}