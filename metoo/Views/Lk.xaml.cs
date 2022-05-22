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
    public partial class Lk : ContentPage
    {
        public Lk()
        {
            InitializeComponent();
            lkEdit.Clicked += Lk_edit;
        }
        private async void Lk_edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LkEdit());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = App.user;
            base.OnAppearing();
        }
    }
}