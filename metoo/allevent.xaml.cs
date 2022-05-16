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

        private async void CreateEventAsync(object sender, EventArgs e)
        {

            EventTable event2 = new EventTable();
            Creat_event eventPage = new Creat_event();
            eventPage.BindingContext = event2;
            await Navigation.PushAsync(new Creat_event());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = App.Database2.GetItems();
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