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
    public partial class LkEdit : ContentPage
    {
        public LkEdit()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            back_button.Clicked += Back_to_Lk;
            save_button.Clicked += Back_to_Lk;
        }
        private async void Back_to_Lk(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}