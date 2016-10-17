using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UTO.Annotations;
using UTO.Util;

namespace UTO.ViewModels
{
    public class UrlListVM : INotifyPropertyChanged
    {
        public ObservableCollection<Url> Urls => DataContainer.GetUrlColl();

        private Url curUrl;

        public Url CurUrl
        {
            get
            {
                return curUrl;
                
            }
            set
            {
                curUrl = value;
                OnPropertyChanged(nameof(CurUrl));
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(DeleteCommandExecute));

        private void DeleteCommandExecute(object obj)
        {
            Urls.Remove(CurUrl);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}