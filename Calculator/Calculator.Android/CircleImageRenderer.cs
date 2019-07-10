using System;
using System.ComponentModel;

using Android.Runtime;
using Android.Views;
using Android.Graphics;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Color = Xamarin.Forms.Color;
using Calculator;
using Calculator.Droid;

[assembly: ExportRenderer(typeof(CircularImage), typeof(CircleImageRenderer))]
namespace Calculator.Droid
{
    //Image Circle Implementation
    [Preserve(AllMembers = true)]
    public class CircleImageRenderer : ImageRenderer
    {
        [Obsolete]
        public CircleImageRenderer()
        {
        }

        public CircleImageRenderer(Context context) : base(context)
        {
        }


        //Used for registration with dependency service
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async static void Init()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


            if (e.PropertyName == CircularImage.BorderColorProperty.PropertyName ||
              e.PropertyName == CircularImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == CircularImage.FillColorProperty.PropertyName)
            {
                this.Invalidate();
            }
        }

        /// <param name="canvas">The canvas on which to draw the child</param><param name="child">Who to draw</param><param name="drawingTime">The time at which draw is occurring</param><summary>Draw one child of this View Group.</summary><returns>To be added.</returns><remarks><para tool="javadoc-to-mdoc">Draw one child of this View Group. This method is responsible for getting
        /// the canvas in the right state. This includes clipping, translating so
        /// that the child's scrolled origin is at 0, 0, and applying any animation
        /// transformations.</para><para tool="javadoc-to-mdoc"><format type="text/html"><a href="http://developer.android.com/reference/android/view/ViewGroup.html#drawChild(android.graphics.Canvas, android.view.View, long)" target="_blank">[Android Documentation]</a></format></para></remarks><since version="Added in API level 1" />
        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            try
            {

                var radius = (float)Math.Min(Width, Height) / 2f;

                var borderThickness = ((CircularImage)Element).BorderThickness;

                float strokeWidth = 0f;

                if (borderThickness > 0)
                {
                    var logicalDensity = Forms.Context.Resources.DisplayMetrics.Density;
                    strokeWidth = (float)Math.Ceiling(borderThickness * logicalDensity + .5f);
                }

                radius -= strokeWidth / 2f;




                var path = new Path();
                path.AddCircle(Width / 2.0f, Height / 2.0f, radius, Path.Direction.Ccw);


                canvas.Save();
                canvas.ClipPath(path);



                var paint = new Paint
                {
                    AntiAlias = true
                };
                paint.SetStyle(Paint.Style.Fill);
                paint.Color = ((CircularImage)Element).FillColor.ToAndroid();
                canvas.DrawPath(path, paint);
                paint.Dispose();


                var result = base.DrawChild(canvas, child, drawingTime);

                path.Dispose();
                canvas.Restore();

                path = new Path();
                path.AddCircle(Width / 2f, Height / 2f, radius, Path.Direction.Ccw);


                if (strokeWidth > 0.0f)
                {
                    paint = new Paint
                    {
                        AntiAlias = true,
                        StrokeWidth = strokeWidth
                    };
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = ((CircularImage)Element).BorderColor.ToAndroid();
                    canvas.DrawPath(path, paint);
                    paint.Dispose();
                }

                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}
