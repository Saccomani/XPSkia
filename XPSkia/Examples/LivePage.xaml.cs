using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;

namespace XPSkia.Examples
{
    public partial class LivePage : ContentPage
    {
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

            //paste the kimono code here
           

        }
    }
}
