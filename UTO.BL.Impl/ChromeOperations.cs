using System;
using System.Diagnostics;
using UTO.BL.Common;

namespace UTO.BL.Impl
{
    public class ChromeOperations : IBrowserOperations
    {
        
        public void Open(string[] urls)
        {
            if (urls.Length > 0)
            {
                var proc = Process.Start("chrome", urls[0] + " --new-window");
                if (proc == null)
                {
                    Console.WriteLine("Can't start Process");
                    return;
                }
                proc.WaitForInputIdle();
                for (int i = 1; i < urls.Length; ++i)
                {
                    proc.StartInfo.Arguments = urls[i];
                    proc.Start();
                }
            }

        } 
    }
}