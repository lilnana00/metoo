using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace metoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vhod : ContentPage
    {
        public Vhod()
        {
            InitializeComponent();
            back_button.Clicked += Back_to_main;
        }
        private async void Back_to_main(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}