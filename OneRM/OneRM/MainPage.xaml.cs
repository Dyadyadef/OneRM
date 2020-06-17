using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneRM
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        enum States
        { 
            SearchExpanded,
            SearchHidden
        }
        public MainPage()
        {
            InitializeComponent();
            SizeChanged += MainPage_SizeChanged;
        }

        Storyboard _storyboard = new Storyboard();

        const int margin = 20;
        const int animationSpeed = 250;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ScrollContainer.Scrolled += ScrollContainer_Scrolled;
        }

        private async void ScrollContainer_Scrolled(object sender, ScrolledEventArgs e)
        {
            if ((e.ScrollY > 0) && (CurrentState != States.SearchHidden))
            {
                _storyboard.Go(States.SearchHidden);
                CurrentState = States.SearchHidden;
                ScrollContainer.IsEnabled = false;
                await Task.Delay(animationSpeed);
                ScrollContainer.IsEnabled = true;
            }
            else if ((e.ScrollY == 0) && (CurrentState != States.SearchExpanded))
            {
                _storyboard.Go(States.SearchExpanded);
                CurrentState = States.SearchExpanded;
                ScrollContainer.IsEnabled = false;
                await Task.Delay(animationSpeed);
                ScrollContainer.IsEnabled = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SizeChanged -= MainPage_SizeChanged;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }
        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            _storyboard = new Storyboard();
            var width = this.Width;
            var height = this.Height;

            // set the position of all the screen elements

            // cart
            Rectangle basketRect = new Rectangle(
                x: width - (BasketIcon.Width + margin),
                y: margin,
                width: BasketIcon.Width,
                height: BasketIcon.Height
                );
            AbsoluteLayout.SetLayoutBounds(BasketIcon, basketRect);

            // search icon
            Rectangle searchRect = new Rectangle(
                x: margin,
                y: 200,
                width: SearchIcon.Width,
                height: SearchIcon.Height
                );
            AbsoluteLayout.SetLayoutBounds(SearchIcon, searchRect);

            Rectangle searchRectCollapsed = new Rectangle(
                x: BasketIcon.Bounds.Left - (margin + SettingsIcon.Width + margin + SearchIcon.Width),
                y: margin,
                width: SearchIcon.Width,
                height: SearchIcon.Height
                );

            // settings icon
            Rectangle settingsRect = new Rectangle(
                x: width - (SettingsIcon.Width + margin),
                y: 200,
                width: SettingsIcon.Width,
                height: SettingsIcon.Height
                );
            AbsoluteLayout.SetLayoutBounds(SettingsIcon, settingsRect);

            Rectangle settingsRectCollapsed = new Rectangle(
                x: BasketIcon.Bounds.Left - (margin + SettingsIcon.Width),
                y: margin,
                width: SettingsIcon.Width,
                height: SettingsIcon.Height
                );

            //SearchBackground
            Rectangle searchBackgroundRect = new Rectangle(
                x: margin,
                y: 200,
                width: SettingsIcon.Bounds.X - (margin + margin),
                height: SearchBackground.Height
                );
            AbsoluteLayout.SetLayoutBounds(SearchBackground, searchBackgroundRect);

            Rectangle searchBackgroundCollapsedRect = new Rectangle(
                x: BasketIcon.Bounds.Left - (margin + SettingsIcon.Width + margin + SearchIcon.Width),
                y: margin,
                width: SettingsIcon.Width,
                height: SettingsIcon.Height
                );

            // ScrollContainer
            Rectangle scrollContainerRect = new Rectangle(
                x: margin,
                y: SearchIcon.Bounds.Bottom + margin,
                width: width - (2 * margin),
                height: height - (SearchIcon.Bounds.Bottom + margin)
                );
            AbsoluteLayout.SetLayoutBounds(ScrollContainer, scrollContainerRect);

            Rectangle scrollContainerRectCollapsed = new Rectangle(
                x: margin,
                y: margin + BasketIcon.Height + margin,
                width: width - (2 * margin),
                height: height - (margin + BasketIcon.Height + margin)
                );

            // add the positions tp the state machine
            _storyboard.Add(States.SearchExpanded, new[]
           {
                new ViewTransition(Header, AnimationType.Opacity, 1, animationSpeed),
                new ViewTransition(SearchEntry, AnimationType.Opacity, 1, animationSpeed),
                new ViewTransition(SettingsIcon, AnimationType.Layout, settingsRect, animationSpeed),
                new ViewTransition(SearchIcon, AnimationType.Layout, searchRect, animationSpeed),
                new ViewTransition(SearchBackground, AnimationType.Layout, searchBackgroundRect, animationSpeed),
                new ViewTransition(ScrollContainer, AnimationType.Layout, scrollContainerRect, animationSpeed)
            });

            _storyboard.Add(States.SearchHidden, new[]
            {
                new ViewTransition(Header, AnimationType.Opacity, 0.01, animationSpeed),
                new ViewTransition(SearchEntry, AnimationType.Opacity, 0.01, animationSpeed),
                new ViewTransition(SettingsIcon, AnimationType.Layout, settingsRectCollapsed, animationSpeed),
                new ViewTransition(SearchIcon, AnimationType.Layout, searchRectCollapsed, animationSpeed),
                new ViewTransition(SearchBackground, AnimationType.Layout, searchBackgroundCollapsedRect, animationSpeed),
                new ViewTransition(ScrollContainer, AnimationType.Layout, scrollContainerRectCollapsed, animationSpeed)
            });
        }

        States CurrentState = States.SearchExpanded;
        private void HamburgerButton_Clicked(object sender, EventArgs e)
        {
            States newState;
            if (CurrentState == States.SearchExpanded)
                newState = States.SearchHidden;
            else
                newState = States.SearchExpanded;

            _storyboard.Go(newState);
            CurrentState = newState;
        }
    }
}
