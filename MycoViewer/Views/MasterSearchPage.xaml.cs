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
                    case "basic": 
                    case "advanced":
                    case "specimens": 
                    case "thesaurus": 
                    case "bibliography":
                        ContentFrame.Navigate(typeof(SearchPage)); break;
                }
            }
        }

        private void MasterSearchNavView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SearchPage));
        }
    }
}
