using System;

using MycoViewer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views
{
    public sealed partial class MycobankLiteratureSearchPage : Page
    {
        private MycobankLiteratureSearchViewModel ViewModel
        {
            get { return DataContext as MycobankLiteratureSearchViewModel; }
        }

        public MycobankLiteratureSearchPage()
        {
            InitializeComponent();
        }
    }
}
