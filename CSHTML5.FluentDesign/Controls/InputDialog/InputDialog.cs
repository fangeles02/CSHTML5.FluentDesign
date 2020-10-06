using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;


public class InputDialogResult
{
    public MessageBoxResult DialogResult { get; set; }
    public string Input { get; set; }
}


public static class InputDialog
{
    public static async Task<InputDialogResult> ShowAsync(string Message)
    {
        InputDialogInterface content = new InputDialogInterface(Message, "");
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }

    public static async Task<InputDialogResult> ShowAsync(string Message, string Title)
    {
        InputDialogInterface content = new InputDialogInterface(Message, Title, "", "OK", "Cancel", false);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }


    public static async Task<InputDialogResult> ShowAccentedAsync(string Message)
    {
        InputDialogInterface content = new InputDialogInterface(Message, "", "", "OK", "Cancel", true);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }



    public static async Task<InputDialogResult> ShowAccentedAsync(string Message, string Title)
    {
        InputDialogInterface content = new InputDialogInterface(Message, Title, "", "OK", "Cancel", true);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }



  


}
