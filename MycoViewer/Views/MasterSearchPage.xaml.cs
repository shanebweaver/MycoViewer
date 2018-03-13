using System;
using System.Linq;
using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class MasterSearchPage : Page
    {
        private MasterSearchViewModel ViewModel
        {
            get { return DataContext as MasterSearchViewModel; }
        }

        public MasterSearchPage()
        {
            InitializeComponent();
        }

        private void MasterSearchNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItem is string)
            {
                NavigationViewItem item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                switch (item?.Tag)
                {
                    case "basic": ContentFrame.Navigate(typeof(MBWSearchPage)); break;
                    case "advanced": ContentFrame.Navigate(typeof(MycobankSearchPage)); break;
                    case "specimens": ContentFrame.Navigate(typeof(MycobankLiteratureSearchPage)); break;
                    case "thesaurus": ContentFrame.Navigate(typeof(MycobankSpecimensSearchPage)); break;
                    case "bibliography": ContentFrame.Navigate(typeof(TaxaDescriptionsSearchPage)); break;
                }
            }
        }

        private void MasterSearchNavView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
}
