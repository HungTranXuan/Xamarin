using System;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism.Navigation;
using Prism.Commands;

namespace ManuallyPrism.ViewModels
{
    public class HomePageViewModel
    {
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);
        }

        async void NavigateAsync(string page)
        {
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}
