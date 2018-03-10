using System;

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

using MycoViewer.Services;
using MycoViewer.Views;

namespace MycoViewer.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<MBWSearchViewModel, MBWSearchPage>();
            Register<MycobankLiteratureSearchViewModel, MycobankLiteratureSearchPage>();
            Register<MycobankSearchViewModel, MycobankSearchPage>();
            Register<MycobankSpecimensSearchViewModel, MycobankSpecimensSearchPage>();
            Register<TaxaDescriptionsSearchViewModel, TaxaDescriptionsSearchPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<UriSchemeExampleViewModel, UriSchemeExamplePage>();
        }

        public UriSchemeExampleViewModel UriSchemeExampleViewModel => ServiceLocator.Current.GetInstance<UriSchemeExampleViewModel>();

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MBWSearchViewModel MBWSearchViewModel => ServiceLocator.Current.GetInstance<MBWSearchViewModel>();

        public MycobankLiteratureSearchViewModel MycobankLiteratureSearchViewModel => ServiceLocator.Current.GetInstance<MycobankLiteratureSearchViewModel>();

        public MycobankSearchViewModel MycobankSearchViewModel => ServiceLocator.Current.GetInstance<MycobankSearchViewModel>();

        public MycobankSpecimensSearchViewModel MycobankSpecimensSearchViewModel => ServiceLocator.Current.GetInstance<MycobankSpecimensSearchViewModel>();

        public TaxaDescriptionsSearchViewModel TaxaDescriptionsSearchViewModel => ServiceLocator.Current.GetInstance<TaxaDescriptionsSearchViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
