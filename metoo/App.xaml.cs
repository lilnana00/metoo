using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace metoo
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "Users.db";
        public const string DATABASE_NAME2 = "Events.db";
        public static UserReprositoryi database;
        public static EventReprositoryi database2;
        public static UserReprositoryi Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserReprositoryi(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public static EventReprositoryi Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new EventReprositoryi(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME2));
                }
                return database2;
            }
        }



        public static User user;

        public App()
        {
            InitializeComponent();

            // MainPage = new MyCalendar();
            MainPage = new NavigationPage(new MainPage()); 
           // MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
