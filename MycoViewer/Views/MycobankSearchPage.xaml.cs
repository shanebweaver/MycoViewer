using System;

using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class MycobankSearchPage : Page
    {
        private MycobankSearchViewModel ViewModel
        {
            get { return DataContext as MycobankSearchViewModel; }
        }

        public MycobankSearchPage()
        {
            InitializeComponent();
        }
    }
}
