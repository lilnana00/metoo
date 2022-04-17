using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace metoo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            vhod_button.Clicked += Go_to_vhod;
        }

        private async void Go_to_vhod(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vhod());
        }
    }
}
