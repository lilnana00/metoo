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
    public partial class Login : ContentPage
    {
        public Login()
        {
            Application.Current.UserAppTheme = OSAppTheme.Light;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back_to_main;
            event_button.Clicked += Go_to_allEvent;
        }
        private async void Back_to_main(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void Go_to_allEvent(object sender, EventArgs e)
        {
            var email = userEmail.Text.ToString();
            var pass = userPass.Text.ToString();
            App.user = App.Database.Login(email, pass);
            if (App.user == null)
            {
                isOk.Text = "Проверьте правильность данных";
                return;
            }

            await Navigation.PushAsync(new AllEvent());
        }
    }
}