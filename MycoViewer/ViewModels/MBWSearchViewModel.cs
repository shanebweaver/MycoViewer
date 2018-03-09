using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mycobank.Services;
using MycoViewer.Models;
using MycoViewer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MycoViewer.ViewModels
{
    public class MBWSearchViewModel : ViewModelBase
    {
        public ICommand SearchCommand;

        private ObservableCollection<string> _searchFields;
        public ObservableCollection<string> SearchFields
        {
            get => _searchFields;
            set => Set(ref _searchFields, value);
        }

        private string _currentSearchField;
        public string CurrentSearchField
        {
            get => _currentSearchField;
            set => Set(ref _currentSearchField, value);
        }

        private ObservableCollection<string> _comparisonOperators;
        public ObservableCollection<string> ComparisonOperators
        {
            get => _comparisonOperators;
            set => Set(ref _comparisonOperators, value);
        }

        private string _currentComparisonOperator;
        public string CurrentComparisonOperator
        {
            get => _currentComparisonOperator;
            set => Set(ref _currentComparisonOperator, value);
        }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set => Set(ref _searchValue, value);
        }

        private string _limit;
        public string Limit
        {
            get => _limit;
            set => Set(ref _limit, value);
        }

        private ObservableCollection<MBWTaxon> _searchResults;
        public ObservableCollection<MBWTaxon> SearchResults
        {
            get => _searchResults;
            set => Set(ref _searchResults, value);
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get => _isSearching;
            set => Set(ref _isSearching, value);
        }

        public MBWSearchViewModel()
        {
            SearchCommand = new RelayCommand(Search);

            SearchFields = new ObservableCollection<string>(Enum.GetNames(typeof(MBWSearchField)));
            ComparisonOperators = new ObservableCollection<string>(Enum.GetNames(typeof(ComparisonOperator)));

            CurrentSearchField = SearchFields[0];
            CurrentComparisonOperator = _comparisonOperators[0];

            SearchValue = string.Empty;
            Limit = string.Empty;

            SearchResults = new ObservableCollection<MBWTaxon>();
            IsSearching = false;
        }

        private async void Search()
        {
            IsSearching = true;

            try
            {
                var searchField = Enum.Parse<MBWSearchField>(_currentSearchField);
                var comparisonOperator = Enum.Parse<ComparisonOperator>(_currentComparisonOperator);
                int? limit = (int.TryParse(_limit, out int tempLimit)) ? (int?)tempLimit : null;
                var searchValue = _searchValue.Trim();

                SearchResults.Clear();
                List<MBWTaxon> searchResults = await MycobankDataService.MBWSearchAsync(searchField, comparisonOperator, searchValue, limit);
                if (searchResults != null)
                {
                    foreach (var searchResult in searchResults)
                    {
                        SearchResults.Add(searchResult);
                    }
                }
            }
            finally
            {
                IsSearching = false;
            }
        }
    }
}
