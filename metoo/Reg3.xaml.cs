using System;
using System.Collections.Generic;
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
        public Reg3()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back_to_reg2;
        }
        private async void Add_photo(object sender, EventArgs e)
        {
            var pickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Avatar"
            });

            if (pickImage != null)
            {
                var stream = await pickImage.OpenReadAsync();
                imgFile.Source = ImageSource.FromStream(() => stream);
                FileName.Text = pickImage.FileName;
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
            user.Age = int.Parse(Age.Text);
            App.Database.SaveItem(user);
            this.Navigation.PushAsync(new Vhod());
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