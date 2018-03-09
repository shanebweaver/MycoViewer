using System;

using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class MBWSearchPage : Page
    {
        private MBWSearchViewModel ViewModel
        {
            get { return DataContext as MBWSearchViewModel; }
        }

        public MBWSearchPage()
        {
            InitializeComponent();
        }
    }
}
