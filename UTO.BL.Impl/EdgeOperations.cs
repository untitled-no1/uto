using System;
using System.Diagnostics;
using UTO.BL.Common;

namespace UTO.BL.Impl
{
    public class EdgeOperations : IBrowserOperations
    {

        public void Open(string[] urls)
        {
            foreach (var url in urls)
            {
                Process.Start("microsoft-edge:http://" + url);
            }

        }
    }
}