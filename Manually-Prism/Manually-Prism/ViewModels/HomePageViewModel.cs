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
                    new HomePageMenuItem { Id = 3, Title = "Page 4" },
                    new HomePageMenuItem { Id = 4, Title = "Page 5" },
            });
            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
        }


    }
}
