﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace metoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reg3 : ContentPage
    {
        public Reg3()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            reg3_button.Clicked += Go_to_vhodr;
            back_button.Clicked += Back_to_reg2;
        }
        private async void Go_to_vhodr(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vhod());
        }
        private async void Back_to_reg2(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void SaveUser(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            if (!String.IsNullOrEmpty(user.Name))
            {
                App.Database.SaveItem(user);
            }
            this.Navigation.PushAsync(new Vhod());
        }
    }
}