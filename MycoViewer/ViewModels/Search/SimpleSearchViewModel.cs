using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MycoViewer.ViewModels.Search
{
    public enum SimpleSearchScope
    {
        All,
        Epithet,
        Species,
        Genus,
        Family,
        Higher
    }

    public static class SimpleSearchScopeExtensions
    {
        public static string GetLocalized(this SimpleSearchScope scope)
        {
            // TODO: Set up localization
            return Enum.GetName(typeof(SimpleSearchScope), scope);
        }
    }

    public class SimpleSearchResult
    {

    }

    public class SimpleSearchViewModel : ViewModelBase
    {
        public RelayCommand SearchCommand { get; private set; }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set => Set(ref _searchQuery, value);
        }

        private ObservableCollection<string> _searchScopes;
        public ObservableCollection<string> SearchScopes
        {
            get => _searchScopes;
            set => Set(ref _searchScopes, value);
        }

        private string _selectedSearchScope;
        public string SelectedSearchScope
        {
            get => _selectedSearchScope;
            set => Set(ref _selectedSearchScope, value);
        }

        private ObservableCollection<SimpleSearchResult> _searchResults;
        public ObservableCollection<SimpleSearchResult> SearchResults;

        public SimpleSearchViewModel()
        {
            SearchCommand = new RelayCommand(Search);
            SearchScopes = new ObservableCollection<string>(Enum.GetValues(typeof(SimpleSearchScope)).Cast<SimpleSearchScope>().Select(s => s.GetLocalized()));
        }

        public void Search()
        {

        }
    }
}
