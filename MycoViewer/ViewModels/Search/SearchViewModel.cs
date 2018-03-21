using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MycoViewer.Search;
using System;
using System.Collections.Generic;
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
            // TODO: Fix localization
            switch(option)
            {
                case MatchOnOption.AllConditions: return "All Conditions";
                case MatchOnOption.AnyConditions: return "Any Conditions";
                default: return string.Empty; // TODO: handle
            }
        }
    }

    

    

    public enum StringSearchComparator
    {
        Contains,
        StartsWith,
        MatchesExactly,
        ValueIsUndefined
    }

    public class SearchCondition
    {
        public string Field { get; set; }
        public int DefaultComparator { get; set; }
        public Type ComparatorType { set; get; }
        public string Value { get; set; }

        public SearchCondition(string field, Type comparatorType, int defaultComparator)
        {
            Field = field;
            ComparatorType = comparatorType;
            DefaultComparator = defaultComparator;
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
        private ObservableCollection<MatchOnOption> _matchOnOptions;
        public ObservableCollection<MatchOnOption> MatchOnOptions
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

        private SearchFieldCollection _searchFields;
        public SearchFieldCollection SearchFields
        {
            get => _searchFields;
            set => Set(ref _searchFields, value);
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
            MatchOnOptions = new ObservableCollection<MatchOnOption>(Enum.GetValues(typeof(MatchOnOption)).Cast<MatchOnOption>().ToList());
            IsAdvancedSearch = false;
            SearchFields = new SearchFieldCollection(SearchFieldExtensions.SearchFieldHierarchy);
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
