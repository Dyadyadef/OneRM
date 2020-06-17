﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        const Int32 animationSpeed = 800;
        internal async Task ExpandToFill(Rectangle bounds)
        {
            // set the initial state
            AddBackground.Opacity = .5;
            AddButton.Opacity = 1;
            NameLabel.Opacity = 1;
            PriceLabel.Opacity = 1;

            // destination rect
            var destRect = new Rectangle(
                x: (bounds.Width / 2) - (this.Width / 2),
                y: 40,
                width: this.Width,
                height: this.Height);

            _ = AddBackground.FadeTo(0, animationSpeed / 2);
            _ = AddButton.FadeTo(0, animationSpeed / 2);
            _ = NameLabel.FadeTo(0, animationSpeed / 2);
            _ = PriceLabel.FadeTo(0, animationSpeed / 2);

            await this.LayoutTo(destRect, animationSpeed * 2, Easing.SinInOut);
            await this.LayoutTo(bounds.Inflate(50, 50), animationSpeed * 2, Easing.SinInOut);
        }
    }
}