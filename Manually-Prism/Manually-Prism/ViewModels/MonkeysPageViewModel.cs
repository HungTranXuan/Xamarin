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
using ManuallyPrism.Models;

namespace ManuallyPrism.ViewModels
{
    public class MonkeysPageViewModel : BindableBase
    {
        public ObservableCollection<Monkey> Monkeys { get { return MonkeyData.Monkeys; } }

        private Monkey selectedMonkey;
        public Monkey SelectedMonkey
        {
            get => selectedMonkey;
            set => SetProperty(ref selectedMonkey, value);
        }

        public MonkeysPageViewModel()
        {

        }
    }
}
