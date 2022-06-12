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
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back;
        }

        private void SendComment(object sender, EventArgs e)
        {
            if (comm.Text != null)
            {
                Comment comment = new Comment();
                comment.CreatorID = App.user.ID;
                comment.EventID = EventID;
                comment.Datetime = DateTime.Now.ToString(@"dd\.MM\.yyyy HH:mm");
                comment.Text = comm.Text;
                App.Database3.SaveItem(comment);
                comm.Text = null;
                Update();
            }
        }
        
        private void Update()
        {
            list.ItemsSource = from Comments in App.Database3.GetEventItems(EventID)
                               from Users in App.Database.GetItems()
                               where Users.ID == Comments.CreatorID
                               select new { CommentCreator = Users.Name, Text = Comments.Text, DateTime = Comments.Datetime };
            MembersButton.Text = App.Database.GetUsersCount(EventID).ToString()+" ТОЖЕ!";
        }

        protected override void OnAppearing()
        {
            Update();
            base.OnAppearing();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void JoinToEvent(object sender, EventArgs e)
        {
            if (App.Database.GetEvent(App.user.ID, EventID) == null)
            {
                App.Database.JoinEvent(new UserEvents
                {
                    EventID = this.EventID,
                    UserID = App.user.ID
                });
                Update();
            }
            else
            {
                DisplayAlert("Внимание", "Вы уже присоединились к данному событию", "ОК");
            }
        }
    }
}