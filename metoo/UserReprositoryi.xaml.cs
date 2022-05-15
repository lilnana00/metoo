using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace metoo
{
    public partial class UserReprositoryi : ContentPage
    {
        
        SQLiteConnection database;
        public UserReprositoryi(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
            InitializeComponent();
        }
        public int Count()
        {
            return database.Table<User>().Count();
        }
        public User Login(string email, string pass)
        {
            List<User> users = database.Query<User>("select * from Users where Email=? and Password=?", email, pass);
            if (users.Count == 1)
                return GetItem(users[0].ID);
            else return null;
        }
        public IEnumerable<User> GetItems()
        {
            return database.Table<User>().ToList();
        }
        public User GetItem(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<User>(id);
        }
        public int SaveItem(User item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
