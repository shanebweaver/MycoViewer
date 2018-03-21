using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MycoViewer.Search
{
    public class SearchFieldTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderTemplate { get; set; }
        public DataTemplate ValueTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (container is FrameworkElement element && item != null && item is SearchFieldItem)
            {
                if (item is SearchFieldItem sfi)
                {
                    return (sfi.SearchFieldSubValues != null && sfi.SearchFieldSubValues.Count > 0) ? HeaderTemplate : ValueTemplate;
                }
            }

            return null;
        }
    }
}
