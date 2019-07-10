using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using ManuallyPrism.Views;

namespace ManuallyPrism.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        INavigationService _navigationService;

        public ObservableCollection<HomePageMenuItem> MenuItems { get; set; }

        private HomePageMenuItem selectedMenuItem;
        public HomePageMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

        public DelegateCommand NavigateCommand { get; private set; }
        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
            {
                    new HomePageMenuItem { Id = 0, Title = "Prism Navigation", PageName = nameof(PrismNavigationPage) },
                    new HomePageMenuItem { Id = 1, Title = "View A", PageName = nameof(ViewA) },
                    new HomePageMenuItem { Id = 2, Title = "View B", PageName = nameof(ViewB) },
                    new HomePageMenuItem { Id = 3, Title = "Prism Tabbed Page", PageName = nameof(PrismTabbedPage) },
                    new HomePageMenuItem { Id = 4, Title = "Page 5" },
            });
            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void Navigate()
        {
            switch (SelectedMenuItem.Id)
            {
                case 0:
                    await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(PrismNavigationPage));
                    break;
                case 1:
                    await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(ViewA));
                    break;
                case 2:
                    await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(ViewB));
                    break;
                case 3:
                    await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(PrismTabbedPage) + "?selectedTab=ViewB");
                    break;
                default:
                    break;
            }
            //await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
        }


    }
}