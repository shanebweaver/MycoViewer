using System.Collections.Generic;
using System.Linq;

namespace MycoViewer.Search
{
    public class SearchFieldItem
    {
        public string SearchFieldName { get; set; }
        public List<string> SearchFieldSubValues { get; set; }

        public SearchFieldItem(SearchField searchField, List<SearchField> subSearchFields)
        {
            SearchFieldName = searchField.GetLocalized();
            SearchFieldSubValues = subSearchFields?.Select((sf) => sf.GetLocalized()).ToList();
        }
    }
}
