using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace metoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reg : ContentPage
    {
        public Reg()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            reg2_button.Clicked += Go_to_reg2;
            back_button.Clicked += Back_to_main;
        }
        private async void Go_to_reg2(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(email.Text, "^[A-Za-z0-9][A-Za-z0-9._-]*[A-Za-z0-9]*@([A-Za-z0-9]+([A-Za-z0-9]*[A-Za-z0-9]+)*.)+[A-Za-z]*$"))
            {
                isOk.Text = "Некорректный E-mail";
                return;
            }
            Reg2 reg2Page = new Reg2
            {
                BindingContext = this.BindingContext
            };
            await Navigation.PushAsync(reg2Page);
        }
        private async void Back_to_main(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}