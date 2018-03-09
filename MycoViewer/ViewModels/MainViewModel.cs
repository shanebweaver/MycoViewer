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
    public class MainViewModel : ViewModelBase
    {
        public ICommand SearchCommand;

        private ObservableCollection<string> _mycobankServices;
        public ObservableCollection<string> MycobankServices
        {
            get => _mycobankServices;
            set => Set(ref _mycobankServices, value);
        }

        private string _currentMycobankService;
        public string CurrentMycobankService
        {
            get => _currentMycobankService;
            set => Set(ref _currentMycobankService, value);
        }

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

        private ObservableCollection<Taxon> _searchResults;
        public ObservableCollection<Taxon> SearchResults
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

        public MainViewModel()
        {
            SearchCommand = new RelayCommand(Search);

            MycobankServices = new ObservableCollection<string>(Enum.GetNames(typeof(MycobankServices)));
            SearchFields = new ObservableCollection<string>(Enum.GetNames(typeof(MBWSearchField)));
            ComparisonOperators = new ObservableCollection<string>(Enum.GetNames(typeof(ComparisonOperator)));

            CurrentMycobankService = MycobankServices[0];
            CurrentSearchField = SearchFields[0];
            CurrentComparisonOperator = _comparisonOperators[0];

            SearchValue = string.Empty;
            Limit = string.Empty;

            SearchResults = new ObservableCollection<Taxon>();
            IsSearching = false;

            PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentMycobankService))
            {
                if (!Enum.TryParse(CurrentMycobankService, out MycobankServices service))
                {
                    throw new ArgumentOutOfRangeException(nameof(service));
                }

                UpdateSearchFields(service);
            }
        }

        private void UpdateSearchFields(MycobankServices service)
        {
            string[] fieldNames;
            switch (service)
            {
                case Services.MycobankServices.MBWService:
                    fieldNames = Enum.GetNames(typeof(MBWSearchField));
                    break;
                case Services.MycobankServices.MycobankLiteratureService:
                    fieldNames = Enum.GetNames(typeof(MycobankLiteratureSearchField));
                    break;
                case Services.MycobankServices.MycobankService:
                    fieldNames = Enum.GetNames(typeof(MycobankSearchField));
                    break;
                case Services.MycobankServices.MycobankSpecimensService:
                    fieldNames = Enum.GetNames(typeof(MycobankSpecimensSearchField));
                    break;
                case Services.MycobankServices.TaxaDescriptionsService:
                    fieldNames = Enum.GetNames(typeof(TaxaDescriptionsSearchField));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(service));
            }

            SearchFields.Clear();
            foreach(string fieldName in fieldNames)
            {
                SearchFields.Add(fieldName);
            }
            CurrentSearchField = SearchFields[0];
        }

        private async void Search()
        {
            IsSearching = true;

            try
            {
                var mycobankService = Enum.Parse<MycobankServices>(_currentMycobankService);
                var comparisonOperator = Enum.Parse<ComparisonOperator>(_currentComparisonOperator);
                int? limit = (int.TryParse(_limit, out int tempLimit)) ? (int?)tempLimit : null;
                var searchValue = _searchValue.Trim();

                SearchResults.Clear();
                List<Taxon> searchResults = await MycobankDataService.SearchAsync(mycobankService, _currentSearchField, comparisonOperator, searchValue, limit);
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
