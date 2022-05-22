using System.Collections.Generic;
using SQLite;

namespace metoo
{
    public class CommentReprository
    {
        SQLiteConnection database3;
        public CommentReprository(string databasePath)
        {
            database3 = new SQLiteConnection(databasePath);
            database3.CreateTable<Comment>();
        }
        public int Count()
        {
            return database3.Table<Comment>().Count();
        }
        public IEnumerable<Comment> GetItems()
        {
            return database3.Table<Comment>().ToList();
        }
        public Comment GetItem(int id) => database3.Get<Comment>(id);
        public int DeleteItem(int id)
        {
            return database3.Delete<Comment>(id);
        }
        public int SaveItem(Comment item)
        {
            if (item.ID != 0)
            {
                database3.Update(item);
                return item.ID;
            }
            else
            {
                return database3.Insert(item);
            }
        }
    }
}