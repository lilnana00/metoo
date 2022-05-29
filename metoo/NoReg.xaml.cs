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
    public partial class no_reg : ContentPage
    {
        public no_reg()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back;
            calendar.Clicked += Calendar;
            events.Clicked += Events;
            chats.Clicked += Chats;
            user.Clicked += LK;
            reg_button.Clicked += Go_to_reg;
            vhod_button.Clicked += Go_to_vhod;
        }
        private async void Calendar(object sender, EventArgs e)
        {
            if (App.user == null) await Navigation.PushAsync(new no_reg());
            else await Navigation.PushAsync(new MyCalendar());
        }
        private async void Chats(object sender, EventArgs e)
        {
            if (App.user == null) await Navigation.PushAsync(new no_reg());
            else await Navigation.PushAsync(new AllChat());
        }
        private async void LK(object sender, EventArgs e)
        {
            if (App.user == null) await Navigation.PushAsync(new no_reg());
            else await Navigation.PushAsync(new Lk());
        }
        private async void Events(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllEvent());
        }
        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void Go_to_reg(object sender, EventArgs e)
        {
            User user = new User();
            Reg regPage = new Reg();
            regPage.BindingContext = user;
            await Navigation.PushAsync(regPage);
        }
        private async void Go_to_vhod(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vhod());
        }
    }
}