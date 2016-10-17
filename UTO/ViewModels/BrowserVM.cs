using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using Microsoft.Win32;
using UTO.BL;
using UTO.Util;

namespace UTO.ViewModels
{
    public class BrowserVM : INotifyPropertyChanged
    {
        private string selectedBrowser = "ie";
        public string SelectedBrowser
        {
            get
            {
                return selectedBrowser;
            }
            set
            {
                selectedBrowser = value;
                DataContainer.Browser = value;
                OnPropertyChanged(nameof(SelectedBrowser));
            }
        }

        private Dictionary<string, bool> installedBrowsers = new Dictionary<string, bool>();
        
        public BrowserVM()
        {
            installedBrowsers["ie"] = true;
            installedBrowsers["edge"] = true;
            installedBrowsers["chrome"] = false;
            installedBrowsers["firefox"] = false;
            installedBrowsers["opera"] = false;
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        string tmp = subkey?.GetValue("DisplayName")?.ToString();
                        if(tmp != null) { 
                            if (tmp.Contains("Google Chrome"))
                            {
                                installedBrowsers["chrome"] = true;
                            } else if (tmp.Contains("Opera"))
                            {
                                installedBrowsers["opera"] = true;
                            } else if (tmp.Contains("Mozilla Firefox"))
                            {
                                installedBrowsers["firefox"] = true;
                            }
                        }
                        if (AllBrowsersInstalled())
                        {
                            break;
                        }
                    }
                }
            }
            EnableInstalledBrowsers();
            SelectBrowser(DataContainer.Browser);
            foreach (var item in installedBrowsers)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        private bool AllBrowsersInstalled()
        {
            foreach (var item in installedBrowsers)
            {
                if (!item.Value)
                {
                    return false;
                }
            }
            return true;
        }

        private void SelectBrowser(string item)
        {

            if (item.Equals("chrome"))
            {
                ChromeEnabled = false;
            }
            else if (item.Equals("ie"))
            {
                IEEnabled = false;
            }
            else if (item.Equals("edge"))
            {
                EdgeEnabled = false;
            }
            else if (item.Equals("firefox"))
            {
                FireFoxEnabled = false;
            }
            else if (item.Equals("opera"))
            {
                OperaEnabled = false;
            }

        }
    

        private void EnableInstalledBrowsers()
        {
            foreach (var item in installedBrowsers)
            {
                if (!item.Value)
                {
                    if (item.Key.Equals("chrome"))
                    {
                        ChromeEnabled = false;
                    }
                    if (item.Key.Equals("firefox"))
                    {
                        FireFoxEnabled = false;
                    }
                    if (item.Key.Equals("opera"))
                    {
                        OperaEnabled = false;
                    }
                }
            }
        }

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
            SelectedBrowser = "chrome";
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
            SelectedBrowser = "firefox";
            EnableAllBrowsers();
            FireFoxEnabled = false;
        }));

        private bool ieEnabled = true;
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
            SelectedBrowser = "ie";
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
            SelectedBrowser = "edge";
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
            SelectedBrowser = "opera";
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
            if(installedBrowsers["chrome"])
                ChromeEnabled = true;
            if (installedBrowsers["firefox"])
                FireFoxEnabled = true;
            IEEnabled = true;
            EdgeEnabled = true;
            if (installedBrowsers["opera"])
                OperaEnabled = true;
        }
    }
}
