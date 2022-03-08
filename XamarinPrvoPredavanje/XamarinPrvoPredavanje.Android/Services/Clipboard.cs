using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinPrvoPredavanje.Services;

namespace XamarinPrvoPredavanje.Droid.Services
{
    internal class Clipboard : IClipboard
    {
        public void SetText(string text)
        {
            var service = (ClipboardManager)Android.App.Application.Context.GetSystemService(Context.ClipboardService);
            service.PrimaryClip = ClipData.NewPlainText("Text", text);
        }
    }
}