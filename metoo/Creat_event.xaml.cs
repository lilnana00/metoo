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
    public partial class Creat_event : ContentPage
    {
        public Creat_event()
        {
            InitializeComponent();
            back_button.Clicked += Back_to_allevent;

        }
        private async void Back_to_allevent(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void SaveEvent(object sender, EventArgs e)
        {
            var event2 = (EventTable)BindingContext;
            if (!String.IsNullOrEmpty(event2.EventName))
            {
                App.Database2.SaveItem(event2);
            }
            this.Navigation.PushAsync(new AllEvent());

        }

    }
}