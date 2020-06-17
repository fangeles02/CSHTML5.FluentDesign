using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

public enum MessageBoxButtons
{
    OK = 0,
    OKCancel = 1,
    OKCancelNeutral = 2
}



public static class Dialog
{
    public static async Task<MessageBoxResult> ShowAsync(string Message)
    {
        DialogInterface content = new DialogInterface(Message, "", MessageBoxButtons.OK);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }

    public static async Task<MessageBoxResult> ShowAsync(string Message, MessageBoxButtons Buttons)
    {
        DialogInterface content = new DialogInterface(Message, "", Buttons);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }

    public static async Task<MessageBoxResult> ShowAsync(string Message, MessageBoxButtons Buttons, string PositiveButtonText, string NegativeButtonText, string NeutralButtonText = "")
    {
        DialogInterface content = new DialogInterface(Message, "", Buttons, PositiveButtonText, NegativeButtonText, NeutralButtonText);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }

    public static async Task<MessageBoxResult> ShowAsync(string Message, string Title)
    {
        DialogInterface content = new DialogInterface(Message, Title, MessageBoxButtons.OK);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }

    public static async Task<MessageBoxResult> ShowAsync(string Message, string Title, MessageBoxButtons Buttons)
    {
        DialogInterface content = new DialogInterface(Message, Title, Buttons);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }

    public static async Task<MessageBoxResult> ShowAsync(string Message, string Title, MessageBoxButtons Buttons, string PositiveButtonText, string NegativeButtonText, string NeutralButtonText = "")
    {
        DialogInterface content = new DialogInterface(Message, Title, Buttons, PositiveButtonText, NegativeButtonText, NeutralButtonText);
        await content.ShowAndWait();


        var a = content.Result;
        return a;
    }
}
