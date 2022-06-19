using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace metoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lk : ContentPage
    {
        public Lk()
        {
            Application.Current.UserAppTheme = OSAppTheme.Light;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            lkEdit.Clicked += Lk_edit;
            exitButton.Clicked += Exit;
            calendar.Clicked += Calendar;
            events.Clicked += Events;
            //chats.Clicked += Chats;
            user.Clicked += LK;
        }
        private async void Lk_edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LkEdit());
        }

        private async void Exit(object sender, EventArgs e)
        {
            App.user = null;
            await Navigation.PopAsync();
        }
        public static string Padezh(int amount, string word)
        {
            if (word == "СОБЫТИЕ")
            {
                if ((((amount % 100) > 10) & ((amount % 100) < 15)) || ((amount % 10) >= 5) || ((amount % 10) == 0)) { word = "СОБЫТИЙ"; }
                else if (((amount % 10) >= 2) && ((amount % 10) < 5)) { word = "СОБЫТИЯ";}
                else { word = "СОБЫТИЕ";}
            }
            else
            {
                if ((((amount % 100) > 10) & ((amount % 100) < 15)) || ((amount % 10) >= 5) || ((amount % 10) == 0)) { word = "КОММЕНТАРИЕВ";}
                else if (((amount % 10) >= 2) && ((amount % 10) < 5)){ word = "КОММЕНТАРИЯ";}
                else{ word = "КОММЕНТАРИЙ";}
            }
            return word;
        }
        protected override void OnAppearing()
        {
            this.BindingContext = App.user;
            if (App.user.Photo != null)
            {
                Stream ms = new MemoryStream(App.user.Photo);
                avatar.Source = ImageSource.FromStream(() => ms);
            }
            EventsCount.Text = App.Database.GetEvents(App.user.ID).Count.ToString();
            visited.Text = Padezh(Convert.ToInt32(EventsCount.Text), "СОБЫТИЕ");
            CreateCount.Text = App.Database2.GetCreatorCount(App.user.ID).ToString();
            added.Text = Padezh(Convert.ToInt32(CreateCount.Text), "СОБЫТИЕ");
            CommentCount.Text = App.Database3.CommentsCount(App.user.ID).ToString();
            comment.Text = Padezh(Convert.ToInt32(CommentCount.Text), "КОММЕНТАРИЙ");
            base.OnAppearing();
        }

        private async void AboutApp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutApp());
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