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
    public partial class AllEvent : ContentPage
    {
        public AllEvent()
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
                CreatorID = ((EventInfo)e.Item).CreatorID
            };
            await Navigation.PushAsync(event2);
        }

        private async void CreateEventAsync(object sender, EventArgs e)
        {
            Creat_event create_Event = new Creat_event
            {
                BindingContext = new EventTable()
            };
            await Navigation.PushAsync(create_Event);
        }

        protected override void OnAppearing()
        {
            this.BindingContext = from Users in App.Database.GetItems()
                                  from Events in App.Database2.GetItems()
                                  where Users.ID == Events.CreatorID
                                  where (DateTime.Now - Events.DT).Days <= 1
                                  select new EventInfo(Events.ID, Users.ID, Events.EventName,
                                            Events.DT.ToString(@"dd\.MM\.yyyy HH:mm"), Events.Details, Events.Tags);
            base.OnAppearing();
        }

        //void OnBtnPressed(object sender, EventArgs ea)
        //{
        //    var keyword = MainSearchBar.Text;
        //    MainListView.ItemsSource =
        //    App.Database2.GetItems().Where(Tags => Tags.ToLower().Contains(keyword.ToLower()));
        //}

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            EventTable selectedEvent = (EventTable)e.SelectedItem;
            Event eventPage2 = new Event();
            eventPage2.BindingContext = selectedEvent;

            await Navigation.PushAsync(new Event());

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

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == 0)
            {
                this.BindingContext = from Users in App.Database.GetItems()
                                      from Events in App.Database2.GetItems()
                                      where Users.ID == Events.CreatorID
                                      where (DateTime.Now - Events.DT).Days <= 1
                                      select new EventInfo(Events.ID, Users.ID, Events.EventName,
                                                Events.DT.ToString(@"dd\.MM\.yyyy HH:mm"), Events.Details, Events.Tags);
            }
            else
            {
                this.BindingContext = from Users in App.Database.GetItems()
                                      from Events in App.Database2.GetItems()
                                      where Users.ID == Events.CreatorID
                                      where Events.Tags == picker.SelectedItem.ToString()
                                      where (DateTime.Now - Events.DT).Days <= 1
                                      select new EventInfo(Events.ID, Users.ID, Events.EventName,
                                                Events.DT.ToString(@"dd\.MM\.yyyy HH:mm"), Events.Details, Events.Tags);
            }
        }
    }

}