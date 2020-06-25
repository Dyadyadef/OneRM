using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneRM.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDisplay : ContentView
    {
        public ExerciseDisplay()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ImageOffsetYProperty =
            BindableProperty.Create(nameof(ImageOffsetY), typeof(int), typeof(ExerciseDisplay), 0);

        public static readonly BindableProperty ImageOffsetXProperty =
            BindableProperty.Create(nameof(ImageOffsetX), typeof(int), typeof(ExerciseDisplay), 0);

        public int ImageOffsetY
        {
            get => (int)GetValue(ImageOffsetYProperty);
            set => SetValue(ImageOffsetYProperty, value);
        }
        public int ImageOffsetX
        {
            get => (int)GetValue(ImageOffsetXProperty);
            set => SetValue(ImageOffsetXProperty, value);
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ImageOffsetYProperty.PropertyName)
                ExerciseImage.TranslationY = ImageOffsetY;
            if (propertyName == ImageOffsetXProperty.PropertyName)
                ExerciseImage.TranslationX = ImageOffsetX;
        }

        public event EventHandler AddToCartClicked;
        public event EventHandler ExerciseClicked;
        
        const Int32 animationSpeed = 300;
        internal async Task ExpandToFill(Rectangle bounds)
        {
            // set the initial state
            AddBackground.Opacity = .5;
            AddButton.Opacity = 1;
            NameLabel.Opacity = 1;
            PriceLabel.Opacity = 1;
            ExerciseImage.Scale = 1;
            ExerciseImage.TranslationX = ImageOffsetX;
            ExerciseImage.TranslationY = ImageOffsetY;

            // destination rect
            var destRect = new Rectangle(
                x: (bounds.Width / 2) - (this.Width / 2),
                y: 50,
                width: this.Width,
                height: this.Height);

            _ = AddBackground.FadeTo(0, animationSpeed / 2);
            _ = AddButton.FadeTo(0, animationSpeed / 2);
            _ = NameLabel.FadeTo(0, animationSpeed / 2);
            _ = PriceLabel.FadeTo(0, animationSpeed / 2);

            _ = ExerciseImage.TranslateTo(0, ExerciseImage.TranslationY, animationSpeed * 2);
            await this.LayoutTo(destRect, animationSpeed * 2, Easing.SinInOut);


            _ = ExerciseImage.ScaleTo(1.5, animationSpeed * 2);
            _ =ExerciseImage.TranslateTo(0, 100, animationSpeed * 2);
            Rectangle expandedBound = bounds.Inflate(50, 50);
            await this.LayoutTo(bounds.Inflate(50, 50), animationSpeed * 2, Easing.SinInOut);
            AbsoluteLayout.SetLayoutBounds(this, expandedBound);
        }

        private void TapExerciseGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = ExerciseClicked;
            handler?.Invoke(this, new EventArgs());
        }

        private void TapAddExerciseGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = AddToCartClicked;
            handler?.Invoke(this, new EventArgs());
        }
    }
}