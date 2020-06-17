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




public partial class DialogInterface : ChildWindow
{
    public MessageBoxResult Result
    {
        get; set;
    }



    public DialogInterface(string Message, string Title, MessageBoxButtons Buttons, string PositiveButtonText = "OK", string NegativeButtonText = "Cancel", string NeutralButtonText = "", bool IsAccented = false)
    {
        this.InitializeComponent();

        Label_Message.Text = Message;
        Label_Title.Text = Title;

        if (Title.TrimEnd().Length == 0)
        {
            Label_Title.Visibility = Visibility.Collapsed;
        }
        else
        {
            Label_Title.Visibility = Visibility.Visible;
        }




        if (Buttons == MessageBoxButtons.OK)
        {
            OKButton.Visibility = Visibility.Visible;
            NeutralButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
        }
        else if (Buttons == MessageBoxButtons.OKCancel)
        {
            OKButton.Visibility = Visibility.Visible;
            NeutralButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Visible;
        }
        else if (Buttons == MessageBoxButtons.OKCancelNeutral)
        {
            OKButton.Visibility = Visibility.Visible;
            NeutralButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
        }

        OKButton.Content = PositiveButtonText;
        CancelButton.Content = NegativeButtonText;
        NeutralButton.Content = NeutralButtonText;


        SolidColorBrush clr = (SolidColorBrush)Application.Current.Resources["ImmersiveSystemAccentBrush"];


        if (IsAccented == false)
        {
            Border_AccentHeader.Visibility = Visibility.Collapsed;

        }
        else
        {
            Border_AccentHeader.Visibility = Visibility.Visible;
            Label_Title.Foreground = clr;
        }


    }



    private async void OKButton_Click(object sender, RoutedEventArgs e)
    {
        ((Storyboard)this.Resources["HideAnimation"]).Begin();
        await Task.Delay(450);

        Result = MessageBoxResult.OK;
        this.DialogResult = true;
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        ((Storyboard)this.Resources["HideAnimation"]).Begin();
        await Task.Delay(450);

        Result = MessageBoxResult.Cancel;
        this.DialogResult = false;
    }



    private async void NeutralButton_Click(object sender, RoutedEventArgs e)
    {
        ((Storyboard)this.Resources["HideAnimation"]).Begin();
        await Task.Delay(450);


        Result = MessageBoxResult.None;
        this.DialogResult = true;
    }

    private void ChildWindow1_Loaded(object sender, RoutedEventArgs e)
    {
        ((Storyboard)this.Resources["ShowAnimation"]).Begin();
    }
}

