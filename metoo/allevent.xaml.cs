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
            InitializeComponent();
            calendar.Clicked += Calendar;
            events.Clicked += Events;
            chats.Clicked += Chats;
            user.Clicked += LK;
            addevent.Clicked += CreateEventAsync;
        }

        private async void GoToEvent(object sender, ItemTappedEventArgs e)
        {
            Event event2 = new Event();
            event2.BindingContext = e.Item as EventTable;
            await Navigation.PushAsync(event2);
        }

        private async void CreateEventAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Creat_event());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = App.Database2.GetItems();
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