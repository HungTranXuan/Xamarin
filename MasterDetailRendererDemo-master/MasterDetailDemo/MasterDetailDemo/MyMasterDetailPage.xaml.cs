using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;

namespace MasterDetailDemo
{
    public enum MasterDetailType
    {
        Default,
        Overlay
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMasterDetailPage : MasterDetailPage, INotifyPropertyChanged
    {


        public readonly static BindableProperty WidthRatioProperty =
                    BindableProperty.Create("WidthRatio",
                    typeof(float),
                    typeof(MyMasterDetailPage),
                    (float)0.2);

        public readonly static BindableProperty RenderModeProperty =
                    BindableProperty.Create("RenderMode",
                    typeof(MasterDetailType),
                    typeof(MyMasterDetailPage),
                    (MasterDetailType)MasterDetailType.Overlay);

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public float WidthRatio
        {
            get
            {
                return (float)GetValue(WidthRatioProperty);
            }
            set
            {
                SetValue(WidthRatioProperty, value);
            }
        }

        public MasterDetailType RenderMode
        {
            get
            {
                return (MasterDetailType)GetValue(RenderModeProperty);
            }
            set
            {
                SetValue(RenderModeProperty, value);
                OnPropertyChanged();
            }

        }

        public MyMasterDetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            WidthRatio = (float)0.6;
            RenderMode = MasterDetailType.Overlay;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MyMasterDetailPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}