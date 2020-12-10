using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;

namespace XPSkia.Examples
{
    public partial class LivePage : ContentPage
    {

        SKPaint outlinePaint = new SKPaint {

            Style = SKPaintStyle.Stroke,
            StrokeWidth = 5,
            Color = SKColors.White
            
        };

        SKPaint arcPaint = new SKPaint
        {

            Style = SKPaintStyle.Stroke,
            StrokeWidth = 30,
            Color = SKColors.Purple,
            PathEffect = SKPathEffect.CreateCorner(10)
        };


        public LivePage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        void chartCanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKRect rect = new SKRect(100, 100, info.Width - 100, info.Height - 100);

            canvas.DrawOval(rect, outlinePaint);

            float startAngle = (float)startAngleSlider.Value;
            float sweepAngle = (float)sweepAngleSlider.Value;


            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, startAngle, sweepAngle);
                canvas.DrawPath(path, arcPaint);
            }
        }

        void Slider_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            if (canvas is null)
                return;
            

            canvas.InvalidateSurface();
        }
    }
}
