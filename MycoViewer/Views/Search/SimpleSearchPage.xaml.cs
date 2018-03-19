using MycoViewer.ViewModels.Search;
using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views.Search
{
    public sealed partial class SimpleSearchPage : Page
    {
        private SimpleSearchViewModel ViewModel => DataContext as SimpleSearchViewModel;

        public SimpleSearchPage()
        {
            InitializeComponent();
        }
    }
}
