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

        public override bool Equals(object obj)
        {
            return obj is SecondPage page;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThirdPage());
        }
    }
}