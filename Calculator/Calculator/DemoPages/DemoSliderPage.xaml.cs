using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calculator
{
    public partial class DemoSliderPage : ContentPage
    {
        public DemoSliderPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = Convert.ToInt32(args.NewValue);
            rotatingLabel.Rotation = value;
            displayLabel.Text = String.Format("The Slider value is {0}", value);
        }
    }
}
