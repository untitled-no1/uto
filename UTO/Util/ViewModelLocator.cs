using UTO.ViewModels;

namespace UTO.Util
{
    public class ViewModelLocator
    {
        private static BrowserVM _browserVM;
        public static BrowserVM BrowserVM => _browserVM ?? (_browserVM = new BrowserVM());

        private static UrlListVM _urlListVM;
        public static UrlListVM UrlListVM => _urlListVM ?? (_urlListVM = new UrlListVM());
    }
}