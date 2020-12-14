
using Xamarin.Forms;

namespace XPSkia.Examples
{
    public partial class KimonoPage : ContentPage
    {
        public KimonoPage()
        {
            InitializeComponent();
        }
        void canvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {

        }
        void btnVoltar_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
