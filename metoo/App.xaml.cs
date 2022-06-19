using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Comfortaa-VariableFont_wght.ttf", Alias = "Comfortaa")]
namespace metoo
{
    public partial class App : Application
    {
        public static User user;

        public const string DATABASE_NAME = "Users.db";
        public const string DATABASE_NAME2 = "Events.db";
        public const string DATABASE_NAME3 = "Comments.db";
        public static UserReprository database;
        public static EventReprository database2;
        public static CommentReprository database3;

        public static UserReprository Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserReprository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                    User admin = new User
                    {
                        Email = "admin",
                        Password = "admin",
                        Name = "admin",
                        Age = 12345
                    };
                    database.SaveItem(admin);
                }
                //database.DeleteAll();
                return database;
            }
        }
        public static EventReprository Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new EventReprository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME2));
                }
               //database2.DeleteAll();
                return database2;
            }
        }
        public static CommentReprository Database3
        {
            get
            {
                if (database3 == null)
                {
                    database3 = new CommentReprository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME3));
                }
                //database3.DeleteAll();
                return database3;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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

