using System;
using ManuallyPrism.ViewModels;
using ManuallyPrism.Views;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Xamarin.Forms;

namespace Manually_Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();


            /*These following 2 lines demonstrates 2 different ways of Absolute Navigation in Prism.
            One with a more details that specified a new Uri and its type of Absolute.
            The other one is the simplified version with a forward slash at the beginning indication Absolute Navigation*/

            //NavigationService.NavigateAsync(new Uri("http://www.Manuall-Prism/HomePage", UriKind.Absolute));
            NavigationService.NavigateAsync("/HomePage");

            //The following line demostrates Deep Linking Navigation
            //NavigationService.NavigateAsync("NavigationPage/PrismNavigationPage/ViewA/ViewB");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<PrismNavigationPage, PrismNavigationPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<PrismTabbedPage, PrismTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MonkeysPage, MonkeysPageViewModel>();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
