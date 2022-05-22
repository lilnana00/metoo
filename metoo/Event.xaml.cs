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
        public Event()
        {
            InitializeComponent();
            back_button.Clicked += Back;
        }

        protected override void OnAppearing()
        {
            EventTable table = new EventTable();
            table = BindingContext as EventTable;
            userName.Text = App.Database.GetItem(table.CreatorID).Name;
            base.OnAppearing();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}