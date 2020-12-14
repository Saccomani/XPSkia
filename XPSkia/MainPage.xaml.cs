using System.ComponentModel;
using Xamarin.Forms;
using XPSkia.Examples;


namespace XPSkia
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OpenDrawLogo_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new AnimationPage());
        }

        void OpenAnimationPage_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new AnimationPage());
        }

        void OpenAStockPage_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new StockViewPage());
        }

        void OpenLivePage_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new LivePage());
        }

        void OpenKimonoPage_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new KimonoPage());  
        }
    }
}
