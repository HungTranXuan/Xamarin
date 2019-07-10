using System;
using System.ComponentModel;
using System.Diagnostics;
using Foundation;
using CoreAnimation;
using CoreGraphics;
using System.Linq;

using Calculator;
using Calculator.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircularImage), typeof(CircleImageRenderer))]
namespace Calculator.iOS
{
    [Preserve(AllMembers = true)]
    public class CircleImageRenderer : ImageRenderer
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

        /// Used for registration with dependency service

        public async static void Init()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
                return;
            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
              e.PropertyName == CircularImage.BorderColorProperty.PropertyName ||
              e.PropertyName == CircularImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == CircularImage.FillColorProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {
            try
            {
                var min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (nfloat)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.BackgroundColor = ((CircularImage)Element).FillColor.ToUIColor();
                Control.ClipsToBounds = true;

                var borderThickness = ((CircularImage)Element).BorderThickness;

                //Remove previously added layers
                var tempLayer = Control.Layer.Sublayers?
                                        .Where(p => p.Name == borderName)
                                       .FirstOrDefault();
                tempLayer?.RemoveFromSuperLayer();

                var externalBorder = new CALayer();
                externalBorder.Name = borderName;
                externalBorder.CornerRadius = Control.Layer.CornerRadius;
                externalBorder.Frame = new CGRect(-.5, -.5, min + 1, min + 1);
                externalBorder.BorderColor = ((CircularImage)Element).BorderColor.ToCGColor();
                externalBorder.BorderWidth = ((CircularImage)Element).BorderThickness;

                Control.Layer.AddSublayer(externalBorder);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }

        private const string borderName = "borderLayerName";
    }
}

