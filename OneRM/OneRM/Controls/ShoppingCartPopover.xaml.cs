using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneRM.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCartPopover : ContentView
    {
        public ShoppingCartPopover()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Collapse();
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // paint object for circles
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 2,
                IsAntialias = true
            };

            SKPaint filledCirclePaint = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 2,
                IsAntialias = true
            };

            SKPaint dottendLinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 2,
                IsAntialias = true,
                PathEffect = SKPathEffect.CreateDash(new float[] { 20, 15}, 0)
            };

            float margin = 40;
            float radius = 15;
            float linePadding = 100;

            canvas.DrawCircle(new SKPoint(margin, info.Height / 2), radius, filledCirclePaint);
            canvas.DrawCircle(new SKPoint(margin, info.Height / 2), radius*2, circlePaint);

            canvas.DrawLine(
                new SKPoint(linePadding, info.Height / 2),
                new SKPoint(info.Width / 2 - linePadding, info.Height / 2),
                circlePaint
                );

            canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), radius, circlePaint);

            canvas.DrawLine(
                new SKPoint(info.Width / 2 + linePadding, info.Height / 2),
                new SKPoint(info.Width - linePadding, info.Height / 2),
                dottendLinePaint
                );

            canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), radius, circlePaint);
        }

        uint animationSpeed = 300;
        internal async Task Expand()
        {
            // set our initial states
            WhiteBackground.TranslationY = this.Height;
            WhiteBackground.IsVisible = true;
            GreenPanel.TranslationY = this.Height;
            ShoppingCartDetails.Opacity = 0;
            Header.Opacity = 0;
            this.Opacity = 1;
            this.IsVisible = true;
            CheckOutButton.ScaleX = 0;

            // expand the white panel (background)
            await WhiteBackground.TranslateTo(0, 0, animationSpeed);

            // expand the green panel (shopping cart list background)
            _ = GreenPanel.TranslateTo(0, 0, animationSpeed);
            _ = ShoppingCartDetails.FadeTo(1, animationSpeed * 2);
            _ = Header.FadeTo(1, animationSpeed * 2);

            // expand the button out
            Animation animation = new Animation();
            animation.Add(0, 1, new Animation(t => CheckOutButton.ScaleX = t, 0, 1, Easing.SpringOut));
            animation.Commit(this, "ButtonAnimation", 16, 500);
        }

        internal async Task Collapse()
        {
            await this.FadeTo(0, animationSpeed);
            this.IsVisible = false;
        }
    }
}