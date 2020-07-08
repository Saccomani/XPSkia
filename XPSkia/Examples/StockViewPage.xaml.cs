using System;
using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XPSkia.Examples
{
    public partial class StockViewPage : ContentPage
    {
        List<double> stockPrices1 = new List<double>();
        List<double> stockPrices2 = new List<double>();

        public StockViewPage()
        {
            InitializeComponent();

            stockPrices1.Clear();
            stockPrices2.Clear();


            for (int i = 0; i < 100; i++)
            {
                stockPrices1.Add(new Random().Next(0, 60));
                stockPrices2.Add(new Random().Next(0, 500));
            }

            chartCanvasView.InvalidateSurface();

        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            if (stockPrices1.Count == 0)
                return;
            

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // AXES
            SKPath path = new SKPath();
            float paddingX = 0.1f * info.Width;
            float paddingY = 0.1f * info.Height;

            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Gray,
                StrokeWidth = 2
            };
            canvas.DrawPath(path, strokePaint);

            // STOCK PRICES
            int numPoints = stockPrices1.Count;
            double minPrice = stockPrices1[0];
            double maxPrice = stockPrices1[0];
            List<double> allPrices = new List<double>();
            allPrices.AddRange(stockPrices1);
            allPrices.AddRange(stockPrices2);
            foreach (double price in allPrices)
            {
                minPrice = Math.Min(minPrice, price);
                maxPrice = Math.Max(maxPrice, price);
            }
            double diffPrices = maxPrice - minPrice;
            double initY = info.Height - paddingY - paddingY * 0.5;
            double endY = paddingY;
            double diffScaleY = -endY + initY;
            double initX = paddingX;
            double endX = info.Width - paddingX;
            double diffScaleX = endX - initX;

            //Axis
            double scale = Math.Pow(10, Math.Floor(Math.Log10(diffPrices)));
            double min = Math.Floor(minPrice / scale) * scale;
            double max = Math.Ceiling(maxPrice / scale) * scale;
            drawAxis(canvas, info.Width, 0, 0, 0, info.Height, min, max, scale, numPoints);

            if (stockPrices1.Count > 0)
            {
                drawOneStockCompany(canvas, initX, initY, min, max - min, diffScaleX,
                    diffScaleY, numPoints, stockPrices1, SKColors.Red);
            }
            if (stockPrices2.Count > 0)
            {
                drawOneStockCompany(canvas, initX, initY, min, max - min, diffScaleX,
                    diffScaleY, numPoints, stockPrices2, SKColors.White);
            }
        }

        void drawAxis(SKCanvas canvas, float width, double minX, double maxX, double scaleX, float height, double minY, double maxY, double scaleY, int numberOfPoints)
        {
            SKPaint grey = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Gray,
                StrokeWidth = 1
            };
                
            SKPaint black = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Gray,
                StrokeWidth = 1
            };

            //Calculate Padding
            float paddingX = 0.1f * width;
            float paddingY = 0.1f * height;

            //Vertical Axis
            canvas.DrawLine(paddingX, height - paddingY, paddingX, paddingY, black);

            double divs = maxY - minY;
            double d = divs / scaleY;
            double ydivs = Math.Round(d);
            int kas = (int)ydivs;
            int yDivs = (int)(Math.Round((maxY - minY) / scaleY));

            for (int i = 0; i <= yDivs; i++)
            {
                float h = 1 - (i * 1f / yDivs);
                h *= height * 0.8f;
                h += paddingY;
                canvas.DrawLine(paddingX, h, width - paddingX, h, grey);
                String text = "" + (i * scaleY + minY) + "€";
                float textX = paddingX - black.MeasureText(text);
                canvas.DrawText(text, paddingX - black.MeasureText(text) - 5, h + black.FontMetrics.CapHeight / 2, black);
            }

            //Horizontal Axis
            int step = 1;
            while (black.MeasureText(".000") * (numberOfPoints / step) > width)
            {
                step++;
            }
            for (int i = 0; i < numberOfPoints; i += step)
            {
                String text = "" + (i - numberOfPoints);
                float w = paddingX + width * 0.8f * i / (numberOfPoints - 1);
                canvas.DrawLine(w, paddingY, w, height - paddingY, grey);
                canvas.DrawText(text, w - black.MeasureText(text) / 2, height - paddingY + black.FontMetrics.CapHeight + 5, black);
            }
        }

        void drawOneStockCompany(SKCanvas canvas, double initX, double initY, double minPrice, double diffPrices,
                double diffScaleX, double diffScaleY, int numPoints, List<double> stockPrices, SKColor color)
        {
            List<double> pricesY = new List<double>();
            List<double> pricesX = new List<double>();
            for (int i = 0; i < stockPrices.Count; i++)
            {
                double price = stockPrices[i];
                double y = initY - (price - minPrice) / diffPrices * diffScaleY;
                pricesY.Add(y);
                double x = initX + i / (double)(numPoints - 1) * diffScaleX;
                pricesX.Add(x);
            }


            SKPath pathStockPrices = new SKPath();
            pathStockPrices.MoveTo((float)pricesX[0], (float)pricesY[0]);
            for (int i = 1; i < stockPrices.Count; i++)
            {
                pathStockPrices.LineTo((float)pricesX[i], (float)pricesY[i]);
            }

            SKPaint strokePaintStockPrices = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = color,
                StrokeWidth = 5,
                IsAntialias = true
            };
            canvas.DrawPath(pathStockPrices, strokePaintStockPrices);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

 
    }
}
