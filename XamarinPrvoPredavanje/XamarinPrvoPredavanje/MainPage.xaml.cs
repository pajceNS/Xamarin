using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinPrvoPredavanje
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            GestureLabel.Text = "Xamarin";
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            LinkLabel.TextColor = Color.Purple;
            Browser.OpenAsync("http://google.rs");
        }
    }
}
