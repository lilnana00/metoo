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
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back_to_allevent;
            Date.MinimumDate = DateTime.Now;
            Date.MaximumDate = new DateTime(DateTime.Now.Year+1, 12, 31);
        }
        private async void Back_to_allevent(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void SaveEvent(object sender, EventArgs e)
        {
            var eventTable = (EventTable)BindingContext;
            eventTable.CreatorID = App.user.ID;
            eventTable.DateTime = Date.Date.ToString(@"dd\.MM\.yyyy") + " " + Time.Time.ToString(@"hh\:mm");
            if (!String.IsNullOrEmpty(eventTable.EventName))
            {
                App.Database2.SaveItem(eventTable);
            }
            this.Navigation.PushAsync(new AllEvent());
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}