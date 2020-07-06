using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XPSkia.Examples
{
    public partial class Stock2ViewPage : ContentPage
    {
        public Stock2ViewPage()
        {
            InitializeComponent();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Gray,
                StrokeWidth = 2
            };

        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
