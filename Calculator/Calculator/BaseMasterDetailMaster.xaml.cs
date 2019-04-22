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
                    new BaseMasterDetailMenuItem { Id = 0, Title = "Page 1" },
                    new BaseMasterDetailMenuItem { Id = 1, Title = "Page 2" },
                    new BaseMasterDetailMenuItem { Id = 2, Title = "Page 3" },
                    new BaseMasterDetailMenuItem { Id = 3, Title = "Page 4" },
                    new BaseMasterDetailMenuItem { Id = 4, Title = "Page 5" },
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
