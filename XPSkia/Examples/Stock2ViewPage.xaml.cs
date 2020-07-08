using System;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XPSkia.Examples
{
    public partial class Stock2ViewPage : ContentPage
    {

        private Stopwatch stopwatch = new Stopwatch();
        const double cycleTime = 1000;

        private bool pageIsActive;
        private SKPaint strokePaint;
        private int XDrawed = 0;
        private int YDrawed = 0;
        public Stock2ViewPage()
        {
            InitializeComponent();

            strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 5
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pageIsActive = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
            
                canvasView.InvalidateSurface();

                if (!pageIsActive)
                {
                    stopwatch.Stop();
                }
                return pageIsActive;
            });

        }

        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            var randonY = new Random().Next(1, 100);

            x1 += 5;
            x2 += 5;
            y1 += randonY;
            y1 += randonY;

            canvas.DrawLine(x1, y1, x2 , y2, strokePaint);
        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
