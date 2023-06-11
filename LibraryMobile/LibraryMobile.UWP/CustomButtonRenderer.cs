using LibraryMobile.UWP;
using LibraryMobile;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Media;
using System;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace LibraryMobile.UWP
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.PointerEntered += Control_PointerEntered;
                Control.PointerExited += Control_PointerExited;
                Control.PointerMoved += Control_PointerMoved;
                Control.PointerPressed += Control_PointerPressed;
                Control.Click += Control_Click;
            }
        }

        private void Control_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var customButton = Element as CustomButton;
            if (customButton.IsEnabled)
            {
                Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.DeepSkyBlue);
            }
        }

        private void Control_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var customButton = Element as CustomButton;
            if (customButton.IsEnabled)
            {
                Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.DeepSkyBlue); // kolor po najechaniu kursora
            }
        }

        //private void Control_Click(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        //{
        //    var customButton = Element as CustomButton;
        //    if (customButton.IsEnabled)
        //    {
        //        Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.DeepSkyBlue);

        //    }
        //}


        private void Control_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var customButton = Element as CustomButton;
            if (customButton.IsEnabled)
            {
                Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.DeepSkyBlue); // kolor po najechaniu kursora
                if (customButton.ImageSource != null && customButton.ImageSource is FileImageSource fileImageSource)
                {
                    string imageName = fileImageSource.File;

                    if (imageName == "heart.png")
                    {
                        customButton.ImageSource = "heart_white.png";
                    }
                    if (imageName == "wishlist.png")
                    {
                        customButton.ImageSource = "wishlist_white.png";
                    }
                    if (imageName == "heart_fill.png")
                    {
                        customButton.ImageSource = "heart_remove.png";
                    }
                    if (imageName == "clear.png")
                    {
                        customButton.ImageSource = "clear_white.png";
                    }
                }
            }
            
        }

        private void Control_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {

            var customButton = Element as CustomButton;
            if (customButton.IsEnabled)
            {
                Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent); // kolor po wyjściu kursora
                if (customButton.ImageSource != null && customButton.ImageSource is FileImageSource fileImageSource)
                {
                    string imageName = fileImageSource.File;

                    if (imageName == "heart_white.png")
                    {
                        customButton.ImageSource = "heart.png";
                    }
                    if (imageName == "wishlist_white.png")
                    {
                        customButton.ImageSource = "wishlist.png";
                    }
                    if (imageName == "heart_remove.png")
                    {
                        customButton.ImageSource = "heart_fill.png";
                    }
                    if (imageName == "clear_white.png")
                    {
                        customButton.ImageSource = "clear.png";
                    }

                }
            }

        }

        private void Control_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var customButton = Element as CustomButton;
            if (customButton.IsEnabled)
            {
                Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.DeepSkyBlue); // kolor po kliknięciu
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                //Control.PointerEntered -= Control_PointerEntered;
                Control.PointerExited -= Control_PointerExited;
                Control.PointerMoved -= Control_PointerMoved;
                Control.PointerPressed -= Control_PointerPressed;
                Control.Click -= Control_Click;
            }

            base.Dispose(disposing);
        }

    }
}



//protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//{
//    base.OnElementPropertyChanged(sender, e);

//    if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
//    {
//        UpdateBackgroundColor();
//    }
//}

//private void UpdateBackgroundColor()
//{
//    var customButton = Element as CustomButton;
//    if (customButton != null)
//    {
//        if (customButton.IsEnabled)
//        {
//            Control.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.White);
//        }
//        else
//        {
//            Control.BackgroundColor = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent);
//        }
//    }
//}