using Mycobank.Services;
using Mycobank.Services.Models;
using MycoViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MycoViewer.Services
{
    public enum MycobankServices
    {
        MBWService,
        MycobankLiteratureService,
        MycobankService,
        MycobankSpecimensService,
        TaxaDescriptionsService
    }

    public static class MycobankDataService
    {
        public static async Task<List<Taxon>> SearchAsync(MBWSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null) =>
            await DoSearchAsync(new MBWSearch(searchField, comparisonOperator, searchValue, limit));

        public static async Task<List<Taxon>> SearchAsync(MycobankLiteratureSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null) =>
            await DoSearchAsync(new MycobankLiteratureSearch(searchField, comparisonOperator, searchValue, limit));

        public static async Task<List<Taxon>> SearchAsync(MycobankSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null) =>
            await DoSearchAsync(new MycobankSearch(searchField, comparisonOperator, searchValue, limit));

        public static async Task<List<Taxon>> SearchAsync(MycobankSpecimensSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null) =>
            await DoSearchAsync(new MycobankSpecimensSearch(searchField, comparisonOperator, searchValue, limit));

        public static async Task<List<Taxon>> SearchAsync(TaxaDescriptionsSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null) =>
            await DoSearchAsync(new TaxaDescriptionsSearch(searchField, comparisonOperator, searchValue, limit));

        public static async Task<List<Taxon>> SearchAsync(MycobankServices mycobankService, string searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null)
        {
            switch (mycobankService)
            {
                case MycobankServices.MBWService:
                    return await SearchAsync(Enum.Parse<MBWSearchField>(searchField), comparisonOperator, searchValue, limit);
                case MycobankServices.MycobankLiteratureService:
                    return await SearchAsync(Enum.Parse<MycobankLiteratureSearchField>(searchField), comparisonOperator, searchValue, limit);
                case MycobankServices.MycobankService:
                    return await SearchAsync(Enum.Parse<MycobankSearchField>(searchField), comparisonOperator, searchValue, limit);
                case MycobankServices.MycobankSpecimensService:
                    return await SearchAsync(Enum.Parse<MycobankSpecimensSearchField>(searchField), comparisonOperator, searchValue, limit);
                case MycobankServices.TaxaDescriptionsService:
                    return await SearchAsync(Enum.Parse<TaxaDescriptionsSearchField>(searchField), comparisonOperator, searchValue, limit);
                default:
                    throw new ArgumentOutOfRangeException(nameof(mycobankService));
            }
        }

        public static async Task<List<MBWTaxon>> MBWSearchAsync(MBWSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null)
        {
            var search = new MBWSearch(searchField, comparisonOperator, searchValue, limit);
            var results = await search.Perform();
            return results?.Taxon?.Select((taxonResult) => new MBWTaxon()
            {
                Id = Convert.ToString(taxonResult._id),
                Authors = taxonResult.authors_,
                CreationDate = taxonResult.creation_date,
                Description_pt = taxonResult.description_pt_,
                E3787 = taxonResult.e3787,
                Epithet = taxonResult.epithet_,
                Gender = taxonResult.gender_,
                LastChangeDate = taxonResult.last_change_date,
                LiteraturePageNumber = taxonResult.literaturepagenr_,
                MycobankNumber = Convert.ToString(taxonResult.mycobanknr_),
                Name = taxonResult.name,
                NameYear = taxonResult.nameyear_,
                U3733 = taxonResult.u3733
            }).ToList();
        }

        public static async Task<List<MycobankLiteratureTaxon>> MycobankLiteratureSearchAsync(MycobankLiteratureSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null)
        {
            var search = new MycobankLiteratureSearch(searchField, comparisonOperator, searchValue, limit);
            var results = await search.Perform();
            return results?.Taxon?.Select((taxonResult) => new MycobankLiteratureTaxon()
            {
                Authors = taxonResult.authors_,
                CreationDate = taxonResult.creation_date,
                Id = Convert.ToString(taxonResult._id),
                LastChangeDate = taxonResult.last_change_date,
                MycobankNumber = Convert.ToString(taxonResult.mycobanknr_),
                Name = taxonResult.name,
            }).ToList();
        }

        public static async Task<List<Taxon>> MycobankSearchAsync(MycobankSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null)
        {
            var search = new MycobankSearch(searchField, comparisonOperator, searchValue, limit);
            return await DoSearchAsync(search);
        }

        public static async Task<List<Taxon>> MycobankSpecimensSearchAsync(MycobankSpecimensSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null)
        {
            var search = new MycobankSpecimensSearch(searchField, comparisonOperator, searchValue, limit);
            return await DoSearchAsync(search);
        }

        public static async Task<List<Taxon>> TaxaDescriptionsSearchAsync(TaxaDescriptionsSearchField searchField, ComparisonOperator comparisonOperator, string searchValue, int? limit = null)
        {
            var search = new TaxaDescriptionsSearch(searchField, comparisonOperator, searchValue, limit);
            return await DoSearchAsync(search);
        }

        private static async Task<List<Taxon>> DoSearchAsync(ISearch search)
        {
            return Transform(await search.Perform());
        }

        private static List<Taxon> Transform(Results results)
        { 
            // Convert the results and return
            return results?.Taxon?.Select((taxonResult) => new Taxon()
                {
                    Id = Convert.ToString(taxonResult._id),
                    Anamorph_pt = taxonResult.anamorph_pt_,
                    Authors = taxonResult.authors_,
                    AuthorsAbbreviated = taxonResult.authorsabbrev_,
                    BasedOn_pt = taxonResult.basedon_pt_,
                    Classification = taxonResult.classification_,
                    CodeToxicity = taxonResult.codetoxicity_,
                    CreationDate = taxonResult.creation_date,
                    CurrentName_pt = taxonResult.currentname_pt_,
                    DatePublic = taxonResult.datepublic_,
                    Description_pt = taxonResult.description_pt_,
                    E3787 = taxonResult.e3787,
                    E4060 = taxonResult.e4060,
                    Epithet = taxonResult.epithet_,
                    Externallinks = taxonResult.externallinks_,
                    FacultativeSynonyms_pt = taxonResult.facultativesynonyms_pt_,
                    Files_pt = taxonResult.files_pt_,
                    Gender = taxonResult.gender_,
                    HumanPathogenicityCode = taxonResult.humanpathogenicitycode_,
                    LastChangeDate = taxonResult.last_change_date,
                    LiteratureJournalBook = taxonResult.literaturejournalbook_,
                    LiteraturePageNumber = taxonResult.literaturepagenr_,
                    Literature_pt = taxonResult.literature_pt_,
                    MycobankNumber = Convert.ToString(taxonResult.mycobanknr_),
                    Name = taxonResult.name,
                    NameStatus = taxonResult.namestatus_,
                    NameStatusExplanation = taxonResult.namestatusexplanation_,
                    NameType = taxonResult.nametype_,
                    NameYear = taxonResult.nameyear_,
                    ObligateSynonyms_pt = taxonResult.obligatesynonyms_pt_,
                    OrthographicalVariantOf_pt = taxonResult.orthvariantof_pt_,
                    PlantPathogenicityCode = taxonResult.plantpathogenicitycode_,
                    Protolog_pt = taxonResult.protolog_pt_,
                    Rank_pt = taxonResult.rank_pt_,
                    Remarks = taxonResult.remarks_,
                    Rlink4703 = taxonResult.rlink4703,
                    SanctionedBy = taxonResult.sanctionedby_,
                    SanctioningName_pt = taxonResult.sanctioningname_pt_,
                    SanctioningRef = taxonResult.sanctioningref_,
                    Specimen_pt = taxonResult.specimen_pt_,
                    Teleomorph_pt = taxonResult.teleomorph_pt_,
                    TypeName_pt = taxonResult.typename_pt_,
                    U3732 = taxonResult.u3732,
                    U3733 = taxonResult.u3733,
                    U3734 = taxonResult.u3734,
                    U3735 = taxonResult.u3735,
                    V4912 = taxonResult.v4912,
                    ValidatedBy_pt = taxonResult.validatedby_pt_
                }).ToList();
        }
    }
}
