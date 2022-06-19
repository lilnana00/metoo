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
    public partial class MyCalendar : ContentPage
    {
        public MyCalendar()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            calendar.Clicked += Calendar;
            events.Clicked += Events;
            //chats.Clicked += Chats;
            user.Clicked += LK;
        }
        private async void GoToEvent(object sender, ItemTappedEventArgs e)
        {
            Event event2 = new Event
            {
                BindingContext = e.Item as EventInfo,
                EventID = ((EventInfo)e.Item).ID,
            };
            await Navigation.PushAsync(event2);
        }
        protected override void OnAppearing()
        {
            this.BindingContext = from UsersToEvents in App.Database.GetEvents(App.user.ID)
                                  from Events in App.Database2.GetItems()
                                  from Users in App.Database.GetItems()
                                  where UsersToEvents.EventID == Events.ID
                                  where Users.ID == Events.CreatorID
                                  where (DateTime.Now - Events.DT).Days <= 1
                                  select new EventInfo(Events.ID, Users.ID, Events.EventName,
                                                       Events.DT.ToString(@"dd\.MM\.yyyy HH:mm"), Events.Details, Events.Tags);
            base.OnAppearing();
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