using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        int clickCount = 0;
        public MainPage(string number = null)
        {
            InitializeComponent();
            Resources["labelStyle"] = Resources["blueStyle"];
            if (!String.IsNullOrEmpty(number))
            {
                Title = number;
            }

            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (clickCount % 2 == 0)
            {
                Resources["labelStyle"] = Resources["redStyle"];
                clickCount = 0;
            }
            else
            {
                Resources["labelStyle"] = Resources["blueStyle"];
                clickCount = 1;
            }
            await Navigation.PopModalAsync(true);
        }
    }
}
