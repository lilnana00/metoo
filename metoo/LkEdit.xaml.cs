using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace metoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LkEdit : ContentPage
    {
        public LkEdit()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void UpdateUser(object sender, EventArgs e)
        { 
            if (!string.IsNullOrWhiteSpace(pass.Text + passOk.Text))
            {
                if (pass.Text != passOk.Text) isOk.Text = "Пароли не совпадают";
                if (!Regex.IsMatch(pass.Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"))
                    isOk.Text = "Некорректный пароль";
                return;
            }
            User user = new User();
            user.ID = App.user.ID;
            user.Name = string.IsNullOrWhiteSpace(name.Text) ? App.user.Name : name.Text;
            user.Email = App.user.Email;
            user.Password = string.IsNullOrWhiteSpace(pass.Text) ? App.user.Password : pass.Text;
            user.Age = string.IsNullOrWhiteSpace(age.Text) ? App.user.Age : int.Parse(age.Text);
            App.Database.SaveItem(user);
            App.user = user;
            await Navigation.PopAsync();
        }
        private void AgeChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue)) return;
            if (!int.TryParse(e.NewTextValue, out int value))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
    }
}