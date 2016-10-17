using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UTO.BL;
using UTO.Util;

namespace UTO.ViewModels
{
    public class BrowserVM : INotifyPropertyChanged
    {
        private string selectedBrowser { get; set; } = "ie";

        private bool chromeEnabled = true;
        public bool ChromeEnabled
        {
            get
            {
                return chromeEnabled;
            }
            set
            {
                chromeEnabled = value;
                OnPropertyChanged(nameof(ChromeEnabled));
            }
        }

        private ICommand selectChrome;
        public ICommand SelectChrome => selectChrome ?? (new RelayCommand((object obj) =>
        {
            selectedBrowser = "chrome";
            EnableAllBrowsers();
            ChromeEnabled = false;
        }));

        private bool firefoxEnabled = true;

        public bool FireFoxEnabled
        {
            get
            {
                return firefoxEnabled;
            }
            set
            {
                firefoxEnabled = value;
                OnPropertyChanged(nameof(FireFoxEnabled));
            }
        }
        private ICommand selectFireFox;
        public ICommand SelectFireFox => selectFireFox ?? (new RelayCommand((object obj) =>
        {
            selectedBrowser = "firefox";
            EnableAllBrowsers();
            FireFoxEnabled = false;
        }));

        private bool ieEnabled = false;
        public bool IEEnabled
        {
            get
            {
                return ieEnabled;
            }
            set
            {
                ieEnabled = value;
                OnPropertyChanged(nameof(IEEnabled));
            }
        }
        private ICommand selectIE;
        public ICommand SelectIE => selectIE ?? (new RelayCommand((object obj) =>
        {
            selectedBrowser = "ie";
            EnableAllBrowsers();
            IEEnabled = false;
        }));

        private bool edgeEnabled = true;
        public bool EdgeEnabled
        {
            get
            {
                return edgeEnabled;
            }
            set
            {
                edgeEnabled = value;
                OnPropertyChanged(nameof(EdgeEnabled));
            }
        }
        private ICommand selectEdge;
        public ICommand SelectEdge => selectEdge ?? (new RelayCommand((object obj) =>
        {
            selectedBrowser = "edge";
            EnableAllBrowsers();
            EdgeEnabled = false;
        }));

        private bool operaEnabled = true;
        public bool OperaEnabled
        {
            get
            {
                return operaEnabled;
            }
            set
            {
                operaEnabled = value;
                OnPropertyChanged(nameof(OperaEnabled));
            }
        }
        private ICommand selectOpera;
        public ICommand SelectOpera => selectOpera ?? (new RelayCommand((object obj) =>
        {
            selectedBrowser = "opera";
            EnableAllBrowsers();
            OperaEnabled = false;
        }));


        private ICommand openBrowser;
        public ICommand OpenBrowser => openBrowser ??(new RelayCommand(OpenBrowserCommand));


        private async void OpenBrowserCommand(object obj)
        {
            await Task.Run(() => BLFactory.CreateBrowserOperations(selectedBrowser).Open(DataContainer.GetUrlArray()));
        }
            


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EnableAllBrowsers()
        {
            ChromeEnabled = true;
            FireFoxEnabled = true;
            IEEnabled = true;
            EdgeEnabled = true;
            OperaEnabled = true;
        }
    }
}
