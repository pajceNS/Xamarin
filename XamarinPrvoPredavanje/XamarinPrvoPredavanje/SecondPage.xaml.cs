using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPrvoPredavanje
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage(int number)
        {
            InitializeComponent();
            NumberLabel.Text = number.ToString();
        }
        protected override void OnAppearing()
        {
            NumberLabel.Text = "Not a number";
        }
        protected override void OnDisappearing()
        {
           // base.OnDisappearing();
        }

        public override bool Equals(object obj)
        {
            return obj is SecondPage page;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new ThirdPage());
            //DisplayAlert("Alert title", "Alert message", "Alert cancel");
            
            var result = await DisplayPromptAsync("Prompt title", "Prompt message", "Prompt ok", "Prompt cancel");
        }
    }
}