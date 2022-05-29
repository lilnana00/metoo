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
    public partial class Event : ContentPage
    {
        public int EventID;
        public Event()
        {
            InitializeComponent();
            back_button.Clicked += Back;
        }

        protected override void OnAppearing()
        {
            Comment comment = new Comment();
            comment.EventID = EventID;
            comment.Text = "abracadabra";
            App.Database3.SaveItem(comment);
            list.ItemsSource = App.Database3.GetEventItems(EventID);
            base.OnAppearing();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}