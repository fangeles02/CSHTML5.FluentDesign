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
    }
}
