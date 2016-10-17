using System.ComponentModel;
using System.Runtime.CompilerServices;
using UTO.Annotations;

namespace UTO.ViewModels
{
    public class Url : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name;}
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}