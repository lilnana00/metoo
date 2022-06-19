using System;
using System.Collections.Generic;
using System.IO;
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
        private ImageSource GetSource(byte[] bytes)
        {
            ImageSource s;
            if (bytes != null)
            {
                Stream ms = new MemoryStream(bytes);
                s = ImageSource.FromStream(() => ms);
            }
            else s = ImageSource.FromFile("add_photo.png");
            return s;
        }

        private void Update()
        {
            list.ItemsSource = from Comments in App.Database3.GetEventItems(EventID)
                               from Users in App.Database.GetItems()
                               where Users.ID == Comments.CreatorID
                               select new CommentInfo(Comments.ID, Comments.CreatorID, Users.Name, Comments.Text, Comments.Datetime, GetSource(Users.Photo));
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
            CreatorID = App.Database2.GetItem(EventID).CreatorID;

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
                    HeightRequest = 40,
                };
                delete.Clicked += Delete;
                buttons.Children.RemoveAt(1);
                buttons.Children.Add(delete);
            }
            if (App.user == null)
            {
                createComm.IsVisible = false;
                frame.HeightRequest -= 40;
            }
            avatar.Source = GetSource(App.Database.GetItem(CreatorID).Photo);
            if (App.user != null) commAvatar.Source = GetSource(App.user.Photo);
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
        private async void Delete(object sender, EventArgs e)
        {   
            if (await DisplayAlert("Внимание", "Вы уверены, что хотите удалить событие?", "Да", "Нет"))
            {
                App.Database.DeleteEvent(EventID);
                App.Database2.DeleteItem(EventID);
                await Navigation.PopAsync();
            }
        }

        private async void DeleteComment(object sender, ItemTappedEventArgs e)
        {
            CommentInfo item = e.Item as CommentInfo;
            if (App.user != null && (App.user.ID == 1 || App.user.ID == item.CreatorID))
            {
                if (await DisplayAlert("Внимание", "Вы уверены, что хотите удалить комментарий?", "Да", "Нет"))
                {
                    App.Database3.DeleteItem(item.ID);
                    Update();
                }
            }
        }
    }
}