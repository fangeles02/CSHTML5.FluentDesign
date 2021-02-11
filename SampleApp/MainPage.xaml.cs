using Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SampleApp
{
    public partial class MainPage : Page
    {
        StatusPopup popupcontrol;
        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...

            popupcontrol = new StatusPopup(Grid1);
        }

        private async void Button_Normal_Click(object sender, RoutedEventArgs e)
        {
            await Dialog.ShowAsync("This is a normal button");
        }

        private async void Button_Accented_Click(object sender, RoutedEventArgs e)
        {
            await Dialog.ShowAsync("This is a accented button");
        }

        private void Button_Test_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(TextBox1.Text);
            Console.WriteLine(PasswordBox1.Password);
        }

        private void Button_ToastSample_Click(object sender, RoutedEventArgs e)
        {
            Toast.MakeText(Grid1, "Hello world! This is a sample toast message", Toast.TOAST_DURATION.LENGTH_SHORT);
        }

        private async void Button_InputDialogSample_Click(object sender, RoutedEventArgs e)
        {
            var res = await InputDialog.ShowAccentedAsync("Please enter any value", "Accented input dialog");
            if (res.DialogResult == MessageBoxResult.OK)
            {
                Toast.MakeText(Grid1, $"You have entered: {res.Input}", Toast.TOAST_DURATION.LENGTH_SHORT);
            }


        }

        private async void Button_InputDialogSample2_Click(object sender, RoutedEventArgs e)
        {
            var res = await InputDialog.ShowAsync("Please enter any value", "Regular input dialog");
            if (res.DialogResult == MessageBoxResult.OK)
            {
                Toast.MakeText(Grid1, $"You have entered: {res.Input}", Toast.TOAST_DURATION.LENGTH_SHORT);
            }
        }

        private void Button_ModalSample_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow childwindow1 = new ChildWindow { Width = 500, Height = 400, Title = "Dynamic Modal", FontSize = 14 };
            childwindow1.Style = (Style)Application.Current.Resources["ModalStyle"];
            childwindow1.ShowAndWait();

            StackPanel pnl1 = new StackPanel();
            TextBlock txt1 = new TextBlock { Text = "This is dynamically created textblock" };
            Button btn1 = new Button { Content = "Dynamic button", Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Left };
            btn1.Click += new RoutedEventHandler((object obj, RoutedEventArgs args) =>
            {
                Toast.MakeText(Grid1, "You have clicked the dynamic button", Toast.TOAST_DURATION.LENGTH_SHORT);
            });
            pnl1.Children.Add(txt1);
            pnl1.Children.Add(btn1);

            childwindow1.Content = pnl1;

        }

        private void Button_ModalSample2_Click(object sender, RoutedEventArgs e)
        {
            SampleModal sm = new SampleModal();
            sm.ShowAndWait();
        }

        private void Button_StatusPopup1_Click(object sender, RoutedEventArgs e)
        {
            popupcontrol.ShowMessage("The quick brown fox jumps over the lazy dog.", 3);
        }
    }
}
