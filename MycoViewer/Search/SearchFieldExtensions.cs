using System;
using System.Collections.Generic;

namespace MycoViewer.Search
{
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
}
