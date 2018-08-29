using System;
using Xamarin.Forms;

namespace MobilePlanningMap
{
    public class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            var stack = new StackLayout { 
                Spacing = 0, 
                Padding = 30, 
                BackgroundColor = @Color.Black, 
                HorizontalOptions = LayoutOptions.FillAndExpand, 
                VerticalOptions = LayoutOptions.FillAndExpand 
            };
            var moveDown = 150;
            var loadingIndicator = new ActivityIndicator { 
                IsRunning = true, 
                Color = @Color.White, 
                HorizontalOptions = LayoutOptions.Center, 
                VerticalOptions = LayoutOptions.Center,
                TranslationY = moveDown
            };
            var loadingText = new Label { 
                FontAttributes = FontAttributes.Bold, 
                Text = "Loading...", 
                TextColor = @Color.White, 
                HorizontalOptions = LayoutOptions.Center, 
                VerticalOptions = LayoutOptions.Center,
                TranslationY = moveDown
            };
            stack.Children.Add(loadingIndicator);
            stack.Children.Add(loadingText);

            Content = stack;
        }
    }
}
