using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace metoo
{
    public partial class App : Application
    {
        
            public const string DATABASE_NAME = "Users.db";
            public static UserReprositoryi database;
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
