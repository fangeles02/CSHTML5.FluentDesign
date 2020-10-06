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




public partial class InputDialogInterface : ChildWindow
{
    public InputDialogResult Result
    {
        get; set;
    }



    public InputDialogInterface(string Message, string Title, string Placeholder = "", string PositiveButtonText = "OK", string NegativeButtonText = "Cancel", bool IsAccented = false)
    {
        this.InitializeComponent();

        Label_Message.Text = Message;
        Label_Title.Text = Title;
        TextBox_Input.PlaceholderText = Placeholder;


        if (Title.TrimEnd().Length == 0)
        {
            Label_Title.Visibility = Visibility.Collapsed;
        }
        else
        {
            Label_Title.Visibility = Visibility.Visible;
        }



        OKButton.Visibility = Visibility.Visible;
        CancelButton.Visibility = Visibility.Visible;



        OKButton.Content = PositiveButtonText;
        CancelButton.Content = NegativeButtonText;



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

        Result = new InputDialogResult {  DialogResult= MessageBoxResult.OK, Input = TextBox_Input.Text };
        this.DialogResult = true;
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        ((Storyboard)this.Resources["HideAnimation"]).Begin();
        await Task.Delay(450);



        Result = new InputDialogResult { DialogResult = MessageBoxResult.Cancel, Input = "" };
        this.DialogResult = false;
    }




    private void ChildWindow1_Loaded(object sender, RoutedEventArgs e)
    {
        ((Storyboard)this.Resources["ShowAnimation"]).Begin();
    }
}

