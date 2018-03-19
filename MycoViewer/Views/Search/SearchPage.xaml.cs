using MycoViewer.ViewModels.Search;
using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views.Search
{
    public sealed partial class SearchPage : Page
    {
        private SearchViewModel ViewModel => DataContext as SearchViewModel;

        public SearchPage()
        {
            InitializeComponent();
        }
    }
}
