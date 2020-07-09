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

            // Fill color for Text Style
            var TextStyleFillColor = new SKColor(0, 0, 0, 255);

            // New Text Style fill paint
            var TextStyleFillPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = TextStyleFillColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true,
                Typeface = SKTypeface.FromFamilyName("Arial Black", SKTypefaceStyle.Bold),
                TextSize = 30f,
                TextAlign = SKTextAlign.Center,   
                IsVerticalText = false,
                TextScaleX = 1f,
                TextSkewX = 0f
            };

            // Draw Text shape
            canvas.DrawText("TIMAÇO BULL SKIA", 373.7559f, 201.8398f, TextStyleFillPaint);

        }
    }
}
