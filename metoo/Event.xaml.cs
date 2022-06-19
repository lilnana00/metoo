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
        public int CreatorID;
        public Event()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back;
            if (App.user != null && (App.user.ID == 1 || App.user.ID == CreatorID))
            {
                Button delete = new Button
                {
                    Text = "УДАЛИТЬ",
                    FontFamily = "Comfortaa",
                    FontAttributes = (FontAttributes)1,
                    TextColor = Color.FromHex("#6A29BB"),
                    BackgroundColor = Color.FromHex("#C4C4C4"),
                    WidthRequest = 140,
                    HeightRequest = 40
                };
                buttons.Children.RemoveAt(1);
                buttons.Children.Add(delete);
            }
            if (App.user == null)
            {
                createComm.IsVisible = false;
            }
        }

        private void SendComment(object sender, EventArgs e)
        {
            if (comm.Text != null)
            {
                Comment comment = new Comment
                {
                    CreatorID = App.user.ID,
                    EventID = EventID,
                    Datetime = DateTime.Now.ToString(@"dd\.MM\.yyyy HH:mm"),
                    Text = comm.Text
                };
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
                               select new { CommentCreator = Users.Name, Comments.Text, DateTime = Comments.Datetime };
            MembersButton.Text = App.Database.GetUsers(EventID).Count().ToString()+" ТОЖЕ!";
        }

        private void JoinToEvent(object sender, EventArgs e)
        {
            if (App.user != null)
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
            else
            {
                DisplayAlert("Внимание", "Вы не авторизованы", "OK");
            }
        }

        protected override void OnAppearing()
        {
            Update();
            base.OnAppearing();
        }
        private async void ShowEventMembers(object sender, EventArgs e)
        {
            EventMembers eventMembers = new EventMembers
            {
                BindingContext = from Users in App.Database.GetItems()
                                 from UserEvents in App.Database.GetUsers(EventID)
                                 where Users.ID == UserEvents.UserID
                                 select new
                                 {
                                     Users.Name,
                                     Users.Age
                                 }
            };
            await Navigation.PushAsync(eventMembers);
        }
        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}