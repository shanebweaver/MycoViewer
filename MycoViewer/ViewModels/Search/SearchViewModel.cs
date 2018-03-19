using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MycoViewer.ViewModels.Search
{
    public enum MatchOnOption
    {
        AnyConditions,
        AllConditions
    }

    public static class MatchOnOptionExtensions
    {
        public static string GetLocalized(this MatchOnOption option)
        {
            switch(option)
            {
                case MatchOnOption.AllConditions: return "All Conditions";
                case MatchOnOption.AnyConditions: return "Any Conditions";
                default: return string.Empty;
            }
        }
    }

    public enum SearchComparator
    {
        Contains,
        StartsWith,
        MatchesExactly,
        ValueIsUndefined
    }

    public class SearchCondition
    {
        public string Field { get; set; }
        public SearchComparator Comparator { get; set; }
        public string Value { get; set; }

        public SearchCondition(string field, SearchComparator comparator, string value)
        {
            Field = field;
            Comparator = comparator;
            Value = value;
        }
    }

    public class SearchResult
    {

    }

    public class SearchViewModel : ViewModelBase
    {
        // Commands
        public RelayCommand SearchCommand;
        public RelayCommand ResetConditionsCommand;

        // Search Conditions
        private ObservableCollection<SearchCondition> _searchConditions;
        public ObservableCollection<SearchCondition> SearchConditions
        {
            get => _searchConditions;
            set => Set(ref _searchConditions, value);
        }

        // Match Options
        private ObservableCollection<string> _matchOnOptions;
        public ObservableCollection<string> MatchOnOptions
        {
            get => _matchOnOptions;
            set => Set(ref _matchOnOptions, value);
        }

        // Search Mode Is Advanced?
        private bool _isAdvancedSearch;
        public bool IsAdvancedSearch
        {
            get => _isAdvancedSearch;
            set => Set(ref _isAdvancedSearch, value);
        }

        // Search Results
        private ObservableCollection<SearchResult> _searchResults;
        public ObservableCollection<SearchResult> SearchResults
        {
            get => _searchResults;
            set => Set(ref _searchResults, value);
        }

        /// <summary>
        /// Constructor: 
        /// </summary>
        public SearchViewModel()
        {
            SearchCommand = new RelayCommand(Search);
            ResetConditionsCommand = new RelayCommand(ResetConditions);

            SearchConditions = new ObservableCollection<SearchCondition>();
            MatchOnOptions = new ObservableCollection<string>(Enum.GetValues(typeof(MatchOnOption)).Cast<MatchOnOption>().Select((o) => o.GetLocalized()));
            IsAdvancedSearch = false;
            SearchResults = new ObservableCollection<SearchResult>();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Search()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected void ResetConditions()
        {
            SearchConditions.Clear();
        }
    }
}
