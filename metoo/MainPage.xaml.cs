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
            Application.Current.UserAppTheme = OSAppTheme.Light;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            vhod_button.Clicked += Go_to_vhod;
            reg_button.Clicked += Go_to_reg;
            vhod1_button.Clicked += Go_to_vhod1;
        }

        private async void Go_to_vhod(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        private async void Go_to_reg(object sender, EventArgs e)
        {
            User user = new User();
            Reg regPage = new Reg();
            regPage.BindingContext = user;
            await Navigation.PushAsync(regPage);
        }
        private async void Go_to_vhod1(object sender, EventArgs e)
        {
            EventTable eventTable = new EventTable();
            AllEvent allEvent = new AllEvent();
            allEvent.BindingContext = eventTable;
            await Navigation.PushAsync(allEvent);
        }
    }
}
