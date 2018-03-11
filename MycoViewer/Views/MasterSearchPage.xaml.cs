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
            NavigationViewItem item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            switch(item.Tag)
            {
                case "mbw": ContentFrame.Navigate(typeof(MBWSearchPage)); break;
                case "mycobank": ContentFrame.Navigate(typeof(MycobankSearchPage)); break;
                case "mycobankLiterature": ContentFrame.Navigate(typeof(MycobankLiteratureSearchPage)); break;
                case "mycobankSpecimens": ContentFrame.Navigate(typeof(MycobankSpecimensSearchPage)); break;
                case "taxaDescriptions": ContentFrame.Navigate(typeof(TaxaDescriptionsSearchPage)); break;
            }
        }
    }
}
