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
            if (pass.Text != passOk.Text)
            {
                isOk.Text = "Пароли не совпадают";
                return;
            }
            if (!Regex.IsMatch(pass.Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"))
            {
                isOk.Text = "Некорректный пароль";
                return;
            }
            Reg3 reg3Page = new Reg3();
            reg3Page.BindingContext = this.BindingContext;
            await Navigation.PushAsync(reg3Page);
        }
        private async void Back_to_reg(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}