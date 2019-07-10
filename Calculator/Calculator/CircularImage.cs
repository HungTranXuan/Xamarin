using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Calculator
{
    [DesignTimeVisible(true)]
    public class CircularImage : Image
    {
        //Thickness property of border
        public static readonly BindableProperty BorderThicknessProperty =
          BindableProperty.Create(propertyName: nameof(BorderThickness),
              returnType: typeof(float),
              declaringType: typeof(CircularImage),
              defaultValue: 0F);

        //Border thinkness of circle Image
        public float BorderThickness
        {
            get { return (float)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        //color property of border
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(propertyName: nameof(BorderColor),
              returnType: typeof(Color),
              declaringType: typeof(CircularImage),
              defaultValue: Color.White);

        //Border Color of circle Image
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        //color property of fill
        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create(propertyName: nameof(FillColor),
              returnType: typeof(Color),
              declaringType: typeof(CircularImage),
              defaultValue: Color.Transparent);

        //fill color of circle image
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public CircularImage()
        {
        }
    }
}
