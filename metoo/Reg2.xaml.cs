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
    public partial class Reg2 : ContentPage
    {
        public Reg2()
        {
            InitializeComponent();
            reg3_button.Clicked += Go_to_reg3;
            back_button.Clicked += Back_to_reg;
        }
        private async void Go_to_reg3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reg3());
        }
        private async void Back_to_reg(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}