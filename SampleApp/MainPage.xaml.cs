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
        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
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
    }
}
