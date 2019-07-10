using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Calculator.Droid;

[assembly: ResolutionGroupName("Calculator")]
[assembly: ExportEffect(typeof(ButtonBackgroundEffect), nameof(ButtonBackgroundEffect))]

namespace Calculator.Droid
{
    public class ButtonBackgroundEffect : PlatformEffect
    {
        Android.Graphics.Color backgroundColor;


        protected override void OnAttached()
        {
            try
            {

                backgroundColor = Android.Graphics.Color.Transparent;
                Control.SetBackgroundColor(backgroundColor);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "Clicked")
                {
                    if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.Gray);
                    }
                    else
                    {
                        Control.SetBackgroundColor(backgroundColor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }
}
