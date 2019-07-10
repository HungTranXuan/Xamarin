using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManuallyPrism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrismTabbedPage : TabbedPage
    {
        public PrismTabbedPage()
        {
            InitializeComponent();
        }
    }
}
