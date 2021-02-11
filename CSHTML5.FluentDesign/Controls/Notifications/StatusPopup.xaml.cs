using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Fluent
{
    public partial class StatusPopup : UserControl
    {

        /// <summary>
        /// Default instance. For manual operations
        /// </summary>
        /// <param name="ParentControl"></param>
        public StatusPopup(Panel ParentControl)
        {
            this.InitializeComponent();

            ParentControl.Children.Add(this);
            MainTranslateTransform.X = 100;

        }

        public static void ShowMessage(Panel ParentControl, string Message,  int Duration)
        {
            this.Opacity = 1;
            TextBlock message = new TextBlock { Text = Message, TextWrapping = TextWrapping.Wrap };
            ContentHolder.Content = message;

            ((Storyboard)this.Resources["Show_StatusPopup"]).Begin();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler<object>(async (object sender, object args) =>
            {
                //hide only   
                ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();
                await Task.Delay(800);

                //remove control
            
                MainTranslateTransform.X = this.ActualWidth;
                timer.Stop();
            });
            timer.Interval = new TimeSpan(0,0,Duration);

            timer.Start();
            

        }

        private void Timer_Tick(object sender, object e)
        {
            throw new NotImplementedException();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
