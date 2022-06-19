using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace metoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reg3 : ContentPage
    {
        public byte[] PhotoBytes = null;
        public static byte[] ReadFully(Stream input)
        {
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                bytes = ms.ToArray();
            }
            return bytes;
        }
        public Reg3()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back_to_reg2;
        }
        private async void Add_photo(Object sender, EventArgs e)
        {
            var pickImage = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
               Title = "Выберите аватар"
            });

            if (pickImage != null)
            {
                var stream = await pickImage.OpenReadAsync();
                PhotoBytes = ReadFully(stream);
                add_photo_button.Source = ImageSource.FromStream(() => new MemoryStream(PhotoBytes));
            }
        }

        private async void Back_to_reg2(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void SaveUser(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Age.Text))
            {
                isOk.Text = "Заполните все поля";
                return;
            }

            var user = (User)BindingContext;
            user.Photo = PhotoBytes;
            user.Age = int.Parse(Age.Text);
            App.Database.SaveItem(user);
            this.Navigation.PushAsync(new Login());
        }

        private void AgeChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue)) return;
            if (!int.TryParse(e.NewTextValue, out int value))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
    }
}