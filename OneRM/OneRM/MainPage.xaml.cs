using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneRM
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

        //protected override void OnAppearing() // Настройка до того как приложение станет видимым.
        //{
        //    base.OnAppearing();

        //    SizeChanged += MainPage_SizeChanged;
        //}
        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    SizeChanged -= MainPage_SizeChanged;
        //}

        const int margin = 20;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // set the position of all the screen elements

            // cart
            Rectangle basketRect = new Rectangle(
                x: Width - (BasketIcon.Width + margin),
                y: margin,
                width: BasketIcon.Width,
                height: BasketIcon.Height
                );

            AbsoluteLayout.SetLayoutBounds(BasketIcon, basketRect);
        }
        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
           
        }
    }
}
