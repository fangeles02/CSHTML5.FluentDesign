using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Fluent
{



    public class Toast : UserControl
    {

        public enum TOAST_DURATION
        {
            LENGTH_SHORT = 4000,
            LENGTH_LONG = 8000
        }


        /// <summary>
        /// Dispalys a toast notification
        /// </summary>
        /// <param name="ParentControl">Panel to host the Toast</param>
        /// <param name="Text">Text to display</param>
        /// <param name="Duration">Toast duration</param>
        public static void MakeText(Panel ParentControl, string Text, TOAST_DURATION Duration)
        {

            Border OuterControl;
            TextBlock Message;


            OuterControl = new Border();
            OuterControl.Name = "OuterControl1";
            OuterControl.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
            OuterControl.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom;
            OuterControl.Margin = new Thickness(10);
            OuterControl.ClipToBounds = true;
            OuterControl.CornerRadius = new CornerRadius(3);
            OuterControl.Opacity = 0;





            Grid grid1 = new Grid();



            Fluent.AcrylicBackground acrylic1 = new AcrylicBackground { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch };
            grid1.Children.Add(acrylic1);

            Border border2 = new Border();
            border2.Background = (Brush)Color.FromArgb(200, 0, 0, 0);


            grid1.Children.Add(border2);

            OuterControl.Child = grid1;






            Message = new TextBlock();
            Message.Foreground = (Brush)Colors.White;
            Message.Margin = new Windows.UI.Xaml.Thickness(15);
            Message.TextWrapping = TextWrapping.Wrap;
            //Message.HorizontalAlignment = HorizontalAlignment.Center;


            grid1.Children.Add(Message);
            Message.Text = Text;

            int d_duration = (int)Duration;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(d_duration);
            timer.Tick += new EventHandler<object>(async (object sender, object args) =>
            {
                DoubleAnimation doubleAnimation2 = new DoubleAnimation { From = 1.0, To = 0.0, Duration = new Duration(TimeSpan.FromMilliseconds(500)), EasingFunction = new EasingFunctionBase { EasingMode = EasingMode.EaseOut } };
                Storyboard.SetTarget(doubleAnimation2, OuterControl);
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(OpacityProperty));

                Storyboard storyBoard2 = new Storyboard();
                storyBoard2.Children.Add(doubleAnimation2);
                storyBoard2.Begin();

                await Task.Delay(500);
                //remove from parent
                ParentControl.Children.Remove(OuterControl);
                timer.Stop();
            });

            ParentControl.Children.Add(OuterControl);


      

            DoubleAnimation doubleAnimation1 = new DoubleAnimation {From = 0.0, To = 1.0, Duration = new Duration(TimeSpan.FromMilliseconds(500)), EasingFunction = new EasingFunctionBase { EasingMode = EasingMode.EaseOut } };
            Storyboard.SetTarget(doubleAnimation1, OuterControl);
            Storyboard.SetTargetProperty(doubleAnimation1, new PropertyPath(OpacityProperty));

            Storyboard storyBoard1 = new Storyboard();
            storyBoard1.Children.Add(doubleAnimation1);
            storyBoard1.Begin();







            timer.Start();


        }




    }
}
