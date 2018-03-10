using System;

using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class MycobankSpecimensSearchPage : Page
    {
        private MycobankSpecimensSearchViewModel ViewModel
        {
            get { return DataContext as MycobankSpecimensSearchViewModel; }
        }

        public MycobankSpecimensSearchPage()
        {
            InitializeComponent();
        }
    }
}
