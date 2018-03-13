using System;
using System.Linq;
using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class MasterIdentificationsPage : Page
    {
        private MasterIdentificationsViewModel ViewModel
        {
            get { return DataContext as MasterIdentificationsViewModel; }
        }

        public MasterIdentificationsPage()
        {
            InitializeComponent();
        }

        private void MasterIdentificationsNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            switch(item.Tag)
            {
                case "pairwiseSequenceAlignments": /*ContentFrame.Navigate(typeof(MBWSearchPage));*/ break;
                case "polyphasicIdentifications": /*ContentFrame.Navigate(typeof(MycobankSearchPage));*/ break;
            }
        }
    }
}
