using System;

using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class TaxaDescriptionsSearchPage : Page
    {
        private TaxaDescriptionsSearchViewModel ViewModel
        {
            get { return DataContext as TaxaDescriptionsSearchViewModel; }
        }

        public TaxaDescriptionsSearchPage()
        {
            InitializeComponent();
        }
    }
}
