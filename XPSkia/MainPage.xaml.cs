﻿using System.ComponentModel;
using Xamarin.Forms;
using XPSkia.Examples;
using XPSkia.Helpers;

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
            Navigation.PushModalAsync(new DrawLogoPage());
        }

        void OpenAnimationPage_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new AnimationPage());
        }

        void OpenAStockPage_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new StockViewPage());
        }

        void OpenAStockPage2_Tapped(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushModalAsync(new Stock2ViewPage());
        }
    }
}
