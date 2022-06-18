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
    public partial class AllChat : ContentPage
    {
        public AllChat()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            calendar.Clicked += Calendar;
            events.Clicked += Events;
            //chats.Clicked += Chats;
            user.Clicked += LK;
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
    }
}