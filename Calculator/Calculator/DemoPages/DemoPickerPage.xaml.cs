using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calculator
{
    public partial class DemoPickerPage : ContentPage
    {
        public DemoPickerPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysPageViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pickerView.Focus();
        }
    }
}
