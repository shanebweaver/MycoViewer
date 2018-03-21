using System.Collections.Generic;

namespace MycoViewer.Search
{
    public class SearchFieldCollection : List<SearchFieldItem>
    {
        public SearchFieldCollection(Dictionary<SearchField, List<SearchField>> hierarchy)
        {
            foreach (var kvp in hierarchy)
            {
                Add(new SearchFieldItem(kvp.Key, kvp.Value));
            }
        }
    }
}
