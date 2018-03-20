using MycoViewer.ViewModels.Search;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views.Search
{
    public class SearchFieldTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (container is FrameworkElement element && item != null && item is KeyValuePair<SearchField, List<SearchField>>)
            {
                var kvp = item as KeyValuePair<SearchField, List<SearchField>>?;
                if (kvp.HasValue)
                {
                    var name = (kvp.Value.Value != null) ? "SearchFieldHeaderTemplate" : "SearchFieldValueTemplate";
                    return element.FindName(name) as DataTemplate;
                }
            }

            return null;
        }
    }
}
