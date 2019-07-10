using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ManuallyPrism.Views;

namespace ManuallyPrism.ViewModels
{
    public class HomePageMasterViewModel : ViewModelBase
    {
        public ObservableCollection<HomePageMenuItem> MenuItems { get; set; }

        public HomePageMasterViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Menu";
            MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
            {
                    new HomePageMenuItem { Id = 0, Title = "Prism Navigation" },
                    new HomePageMenuItem { Id = 1, Title = "Page 2" },
                    new HomePageMenuItem { Id = 2, Title = "Page 3" },
                    new HomePageMenuItem { Id = 3, Title = "Page 4" },
                    new HomePageMenuItem { Id = 4, Title = "Page 5" },
            });
        }

        //#region INotifyPropertyChanged Implementation
        //public event PropertyChangedEventHandler PropertyChanged;
        //void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    if (PropertyChanged == null)
        //        return;

        //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //#endregion
    }
}