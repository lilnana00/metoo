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

        class Shtuka
        {
            public Shtuka(int ID, string CreatorName, string EventName, string DateTime, string Details, string Tags)
            {
                this.ID = ID;
                this.CreatorName = CreatorName;
                this.EventName = EventName;
                this.DateTime = DateTime;
                this.Details = Details;
                this.Tags = Tags;
            }
            public int ID { get; set; }
            public string CreatorName { get; set; }
            public string EventName { get; set; }
            public string DateTime { get; set; }
            public string Details { get; set; }
            public string Tags  { get; set; }
        }
        public AllEvent()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            calendar.Clicked += Calendar;
            events.Clicked += Events;
            chats.Clicked += Chats;
            user.Clicked += LK;
        }

        private async void GoToEvent(object sender, ItemTappedEventArgs e)
        {
            Event event2 = new Event
            {
                BindingContext = e.Item as Shtuka,
                EventID = ((Shtuka)e.Item).ID,
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
                                  select new Shtuka(Events.ID,Users.Name,Events.EventName,
                                            Events.DateTime, Events.Details, Events.Tags);
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
    }
}