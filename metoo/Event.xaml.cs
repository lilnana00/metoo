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
        public Event()
        {
            InitializeComponent();
            back_button.Clicked += Back_to_allevent;
        }

        private async void Back_to_allevent(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}