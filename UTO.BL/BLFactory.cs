using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTO.BL.Common;
using UTO.BL.Impl;

namespace UTO.BL
{
    public static class BLFactory
    {
        public static IBrowserOperations CreateBrowserOperations(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                    return new ChromeOperations();
                case "firefox":
                    return new FireFoxOperations();
                case "edge":
                    return new EdgeOperations();
                case "opera":
                    return new OperaOperations();
                case "ie":
                default:
                    return new InternetExplorerOperations();
            }
        }
    }
}
