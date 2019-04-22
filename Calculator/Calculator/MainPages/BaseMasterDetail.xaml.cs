using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseMasterDetail : MasterDetailPage
    {
        public BaseMasterDetail()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as BaseMasterDetailMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;

            switch (item.Id)
            {
                case 0:
                    Detail = new NavigationPage(new BaseMasterDetailDetail());
                    IsPresented = false;
                    break;
                case 1:
                    Detail = new NavigationPage(new DemoTabbedPage());
                    IsPresented = false;
                    break;
                case 2:
                    Detail = new NavigationPage(new DemoCarousedPage());
                    IsPresented = false;
                    break;
                case 3:
                    Detail = new NavigationPage(new DemoLabelPage());
                    IsPresented = false;
                    break;
                case 4:
                    Detail = new NavigationPage(new DemoEntryPage());
                    IsPresented = false;
                    break;
                case 5:
                    Detail = new NavigationPage(new DemoPickerPage());
                    IsPresented = false;
                    break;
                default:
                    return;
            }
        }
    }
}
