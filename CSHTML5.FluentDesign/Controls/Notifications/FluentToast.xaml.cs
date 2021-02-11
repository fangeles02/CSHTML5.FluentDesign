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
    public partial class FluentToast : UserControl
    {

        bool is_shown = false;


        Grid progress_holder = new Grid();
        ProgressBar progress_bar = new ProgressBar();
        TextBlock ProgressTitle = new TextBlock(), ProgressMessage = new TextBlock();



        /// <summary>
        /// Default instance. For manual operations
        /// </summary>
        /// <param name="ParentControl"></param>
        public FluentToast(Panel ParentControl)
        {
            this.InitializeComponent();

            ParentControl.Children.Add(this);
            MainTranslateTransform.X = 100;

            initialize_progress_prompt();

        }


        private void initialize_progress_prompt()
        {
            progress_holder = new Grid();

            ProgressTitle = new TextBlock { TextWrapping = TextWrapping.Wrap, FontSize = 16, FontWeight = Windows.UI.Text.FontWeights.SemiBold, Visibility = Visibility.Collapsed };
            ProgressMessage = new TextBlock { TextWrapping = TextWrapping.Wrap, Margin = new Thickness(0, 3, 0, 0), Visibility = Visibility.Collapsed, MinWidth = 200 };

            RowDefinition r0 = new RowDefinition();
            RowDefinition r1 = new RowDefinition { Height = GridLength.Auto };
            progress_holder.RowDefinitions.Add(r0);
            progress_holder.RowDefinitions.Add(r1);

            StackPanel pnl = new StackPanel { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(0, 0, 0, 10) };
            pnl.Children.Add(ProgressTitle);
            pnl.Children.Add(ProgressMessage);
            progress_holder.Children.Add(pnl);


            progress_bar = new ProgressBar { Maximum = 100, Value = 50, Height = 5, Visibility = Visibility.Collapsed, MinWidth = 200 };
            Grid.SetRow(progress_bar, 1);
            progress_holder.Children.Add(progress_bar);



            ContentHolder.Content = progress_holder;
        }



        public void Show(string Message, int Duration)
        {


            this.Opacity = 1;

            ProgressTitle.Visibility = Visibility.Collapsed;
            ProgressMessage.Visibility = Visibility.Visible;
            progress_bar.Visibility = Visibility.Collapsed;

            ProgressMessage.Text = Message;

            MainTranslateTransform.X = this.ActualWidth;

            ((Storyboard)this.Resources["Show_StatusPopup"]).Begin();
            is_shown = true;


            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler<object>(async (object sender, object args) =>
            {
                //hide only   
                ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                await Task.Delay(800);

                is_shown = false;
                timer.Stop();
            });
            timer.Interval = new TimeSpan(0, 0, 0, 0, Duration);

            timer.Start();
        }


        public void Show(string Message, string Title, int Duration)
        {

            ProgressTitle.Visibility = Visibility.Visible;
            ProgressMessage.Visibility = Visibility.Visible;
            progress_bar.Visibility = Visibility.Collapsed;

            ProgressTitle.Text = Title;
            ProgressMessage.Text = Message;


            MainTranslateTransform.X = this.ActualWidth;

            ((Storyboard)this.Resources["Show_StatusPopup"]).Begin();
            is_shown = true;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler<object>(async (object sender, object args) =>
            {
                //hide only   
                ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                await Task.Delay(800);

                is_shown = false;
                timer.Stop();
            });
            timer.Interval = new TimeSpan(0, 0, 0, 0, Duration);

            timer.Start();
        }


        public async void ShowWithProgress(string Message, int Progress)
        {


            //check if shown
            if (is_shown == true)
            {
                //update the progress only
                ProgressMessage.Text = Message;
                progress_bar.SetValue(Progress);

                if (Progress >= 100)
                {
                    await Task.Delay(3000);

                    ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                    await Task.Delay(800);

                    is_shown = false;
                }
            }
            else
            {
                //show the 
                ProgressTitle.Visibility = Visibility.Collapsed;
                ProgressMessage.Visibility = Visibility.Visible;
                progress_bar.Visibility = Visibility.Visible;

                ProgressMessage.Text = Message;
                progress_bar.SetValue(Progress);


                ((Storyboard)this.Resources["Show_StatusPopup"]).Begin();
                is_shown = true;


                if (Progress >= 100)
                {
                    await Task.Delay(3000);

                    ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                    await Task.Delay(800);

                    is_shown = false;
                }
            }
        }

        public async void ShowWithProgress(string Message,string Title, int Progress)
        {


            //check if shown
            if (is_shown == true)
            {
                //update the progress only
                ProgressMessage.Text = Message;
                progress_bar.SetValue(Progress);


                if (Progress >= 100)
                {
                    await Task.Delay(3000);

                    ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                    await Task.Delay(800);

                    is_shown = false;
                }
            }
            else
            {
                //show the 
                ProgressTitle.Visibility = Visibility.Visible;
                ProgressMessage.Visibility = Visibility.Visible;
                progress_bar.Visibility = Visibility.Visible;

                ProgressTitle.Text = Title;
                ProgressMessage.Text = Message;
                progress_bar.SetValue(Progress);



                ((Storyboard)this.Resources["Show_StatusPopup"]).Begin();
                is_shown = true;


                if (Progress >= 100)
                {
                    await Task.Delay(3000);

                    ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                    await Task.Delay(800);

                    is_shown = false;
                }
            }
        }


        public async void SetProgress(int Value)
        {
            progress_bar.SetValue(Value);

            if (Value >= 100)
            {
                await Task.Delay(3000);

                ((Storyboard)this.Resources["Hide_StatusPopup"]).Begin();

                await Task.Delay(800);

                is_shown = false;
            }

        }


        public int GetProgressValue()
        {
            return (int)progress_bar.Value;
        }

    }
}
