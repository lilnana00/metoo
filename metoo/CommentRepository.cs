using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace metoo
{
    public class CommentRepository
    {
        SQLiteConnection database3;
        public CommentRepository(string databasePath)
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

        public IEnumerable<Comment> GetEventItems(int id)
        {
            return database3.Query<Comment>("select * from Comments where EventID = ?", id);
        }
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
        public int CommentsCount(int ID)
        {
            return database3.Query<Comment>("select * from Comments where CreatorID=?", ID).Count();
        }
    }
}