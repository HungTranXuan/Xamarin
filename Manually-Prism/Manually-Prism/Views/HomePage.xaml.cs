using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ManuallyPrism.ViewModels;

namespace ManuallyPrism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MasterDetailPage, IMasterDetailPageOptions
    {
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public HomePage()
        {
            InitializeComponent();
            //_navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);
            MasterPage.ListView.ItemSelected += ListView_ItemSelectedAsync;
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        public bool IsPresentedAfterNavigation
        {
            get { return true; }
        }



        async void NavigateAsync(string page)
        {
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }

        private async void ListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomePageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            switch (item.Id)
            {
                case 0:
                    Detail = (Page)await _navigationService.NavigateAsync("PrismNavigationPage");
                    IsPresented = false;
                    break;
                case 1:
                    Detail = new NavigationPage(page);
                    IsPresented = false;
                    break;
                default:
                    return;
            }

            MasterPage.ListView.SelectedItem = null;
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as HomePageMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    MasterPage.ListView.SelectedItem = null;
        //}
    }
}
