using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinPrvoPredavanje.NewFolder;

namespace XamarinPrvoPredavanje
{
    public partial class MainPage : ContentPage
    {
        private int counter=0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new Light());

            if (counter%2 == 0)
            {
                mergedDictionaries.Add(new Light());
            }
            else
            {
                mergedDictionaries.Add(new Dark());
            }
            counter++;
        }
    }
}
