using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

    public enum SearchField
    {
        AnyTextField,
        RecordId,
        TaxonName,
        GeneralInformation, //
        Synonymy,
        MycoBankNumber,
        Epithet,
        Rank,
        OrthographicVariantOf,
        Authors,
        AuthorsAbbreviated,
        Literature,
        PageNumber,
        JournalOrBook,
        YearOfPublication,
        NameType,
        Gender,
        DatePublic,
        NameStatus,
        CommentOnNameStatus,
        Remarks,
        SanctioningRef,
        SanctionedBy,
        SanctioningName,
        ValidatedBy,
        TypeSpecimenOrExType,
        MoreSpecimens,
        HumanPathogenicityCode,
        PlantPathogenicityCode,
        CodeToxicity,
        ClassificationAndAssociatedTaxa, //
        CurrentName,
        Classification,
        TypeName,
        Basionym,
        ObligateOrHomotypicSynonyms,
        AnamorphSynonyms,
        TeleomorphSynonyms,
        FacultativeOrHeterotypicSynonyms,
        TypeOfOrganism,
        Descriptions, // 
        Description,
        Protolog,
        LinkOutToExternalResources, //
        OtherFungalLinks,
        BibliographyLinks,
        GeneralLinks,
        MolecularLinks,
        SpecimensAndStrainsLinks,
        Files, //
        AssociatedFiles
    }

    public static class SearchFieldExtensions
    {
        public static string GetLocalized(this SearchField searchField)
        {
            return Enum.GetName(typeof(SearchField), searchField); // TODO Fix Localization
        }

        public static Dictionary<SearchField, List<SearchField>> SearchFieldHierarchy { get; } = new Dictionary<SearchField, List<SearchField>>
        {
            { SearchField.AnyTextField, null },
            { SearchField.RecordId, null },
            { SearchField.TaxonName, null },
            {
                SearchField.GeneralInformation, new List<SearchField>
                {
                    SearchField.Synonymy,
                    SearchField.MycoBankNumber,
                    SearchField.Epithet,
                    SearchField.Rank,
                    SearchField.OrthographicVariantOf,
                    SearchField.Authors,
                    SearchField.AuthorsAbbreviated,
                    SearchField.Literature,
                    SearchField.PageNumber,
                    SearchField.JournalOrBook,
                    SearchField.YearOfPublication,
                    SearchField.NameType,
                    SearchField.Gender,
                    SearchField.DatePublic,
                    SearchField.NameStatus,
                    SearchField.CommentOnNameStatus,
                    SearchField.Remarks,
                    SearchField.SanctioningRef,
                    SearchField.SanctionedBy,
                    SearchField.SanctioningName,
                    SearchField.ValidatedBy,
                    SearchField.TypeSpecimenOrExType,
                    SearchField.MoreSpecimens,
                    SearchField.HumanPathogenicityCode,
                    SearchField.PlantPathogenicityCode,
                    SearchField.CodeToxicity
                }
            },
            {
                SearchField.ClassificationAndAssociatedTaxa, new List<SearchField>
                {
                    SearchField.CurrentName,
                    SearchField.Classification,
                    SearchField.TypeName,
                    SearchField.Basionym,
                    SearchField.ObligateOrHomotypicSynonyms,
                    SearchField.AnamorphSynonyms,
                    SearchField.TeleomorphSynonyms,
                    SearchField.FacultativeOrHeterotypicSynonyms,
                    SearchField.TypeOfOrganism
                }
            },
            {
                SearchField.Descriptions, new List<SearchField>
                {
                    SearchField.Description,
                    SearchField.Protolog
                }
            },
            {
                SearchField.LinkOutToExternalResources, new List<SearchField>
                {
                    SearchField.OtherFungalLinks,
                    SearchField.BibliographyLinks,
                    SearchField.GeneralLinks,
                    SearchField.MolecularLinks,
                    SearchField.SpecimensAndStrainsLinks
                }
            },
            {
                SearchField.Files, new List<SearchField>
                {
                    SearchField.AssociatedFiles
                }
            }
        };
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

        private Dictionary<SearchField, List<SearchField>> _searchFields;
        public Dictionary<SearchField, List<SearchField>> SearchFields
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
            SearchFields = new Dictionary<SearchField, List<SearchField>>(SearchFieldExtensions.SearchFieldHierarchy);
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
