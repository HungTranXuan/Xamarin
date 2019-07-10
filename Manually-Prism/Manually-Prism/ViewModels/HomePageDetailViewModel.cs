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
    public class HomePageDetailViewModel : ViewModelBase
    {
        public HomePageDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Details";
        }
    }
}
