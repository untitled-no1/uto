using System;
using System.Diagnostics;
using System.Text;
using UTO.BL.Common;

namespace UTO.BL.Impl
{
    public class FireFoxOperations : IBrowserOperations
    {

        public void Open(string[] urls)
        {
            
            if (urls.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" ");
                foreach (string url in urls)
                {
                    sb.Append(" -new-tab -url " + url);
                }
                var proc = Process.Start("firefox", sb.ToString());
                if (proc == null)
                {
                    Console.WriteLine("Can't start Process");
                    return;
                }
                proc.WaitForInputIdle();
                
            }

        }
    }
}