using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseMasterDetailMaster : ContentPage
    {
        public ListView ListView;

        public BaseMasterDetailMaster()
        {
            InitializeComponent();

            BindingContext = new BaseMasterDetailMasterViewModel();
            ListView = MenuItemsListView;
        }

        class BaseMasterDetailMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BaseMasterDetailMenuItem> MenuItems { get; set; }

            public BaseMasterDetailMasterViewModel()
            {
                MenuItems = new ObservableCollection<BaseMasterDetailMenuItem>(new[]
                {
                    new BaseMasterDetailMenuItem { Id = 0, Title = "Main Page"},
                    new BaseMasterDetailMenuItem { Id = 1, Title = "Tabbed Page" },
                    new BaseMasterDetailMenuItem { Id = 2, Title = "Caroused Page" },
                    new BaseMasterDetailMenuItem { Id = 3, Title = "Demo Label" },
                    new BaseMasterDetailMenuItem { Id = 4, Title = "Demo Entry" },
                    new BaseMasterDetailMenuItem { Id = 5, Title = "Demo Picker" },
                    new BaseMasterDetailMenuItem { Id = 6, Title = "Demo Slider"},
                    new BaseMasterDetailMenuItem { Id = 7, Title = "Demo Date Picker"},
                    new BaseMasterDetailMenuItem { Id = 8, Title = "Demo Time Picker"},
                    new BaseMasterDetailMenuItem { Id = 9, Title = "Demo Images"},
                    new BaseMasterDetailMenuItem { Id = 10, Title = "Demo Triggers"}
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
