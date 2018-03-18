using System;
using CommonServiceLocator; // using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;


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
            Register<MasterIdentificationsViewModel, MasterIdentificationsPage>();
            Register<MasterSearchViewModel, MasterSearchPage>();
            Register<SearchViewModel, SearchPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<UriSchemeExampleViewModel, UriSchemeExamplePage>();
        }

        public UriSchemeExampleViewModel UriSchemeExampleViewModel => ServiceLocator.Current.GetInstance<UriSchemeExampleViewModel>();

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MasterIdentificationsViewModel MasterIdentificationsViewModel => ServiceLocator.Current.GetInstance<MasterIdentificationsViewModel>();

        public MasterSearchViewModel MasterSearchViewModel => ServiceLocator.Current.GetInstance<MasterSearchViewModel>();

        public SearchViewModel SearchViewModel => ServiceLocator.Current.GetInstance<SearchViewModel>();

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
