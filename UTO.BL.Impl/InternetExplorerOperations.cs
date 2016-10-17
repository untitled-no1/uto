using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using SHDocVw;
using UTO.BL.Common;

namespace UTO.BL.Impl
{
    public class InternetExplorerOperations : IBrowserOperations
    {

        public void Open(string[] urls)
        {
            if (urls.Length > 0)
            {
                foreach (var url in urls)
                {
                    ShellWindows iExplorerInstances = new ShellWindows();
                    bool found = false;
                    foreach (InternetExplorer iExplorer in iExplorerInstances)
                    {
                        if (iExplorer.Name == "Internet Explorer")
                        {
                            iExplorer.Navigate(url, 0x800);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Created New Instance, because not found!");
                        var proc = Process.Start("IExplore.exe", url);
                        proc.WaitForInputIdle();
                        Thread.Sleep(2000);
                    }
                }
            }

        }
    }
}