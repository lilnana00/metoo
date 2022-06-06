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
            eventTable.DT = new DateTime(Date.Date.Year, Date.Date.Month, Date.Date.Day, Time.Time.Hours, Time.Time.Minutes, 0);
            eventTable.Tags = picker.SelectedItem.ToString();
            eventTable.IsActive = true;
            if (!String.IsNullOrEmpty(eventTable.EventName))
            {
                App.Database2.SaveItem(eventTable);
            }
            this.Navigation.PushAsync(new AllEvent());
        }     
    }
}