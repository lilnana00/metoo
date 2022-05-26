using System.Collections.Generic;
using SQLite;

namespace metoo
{
    public class EventReprositoryi
    {
        SQLiteConnection database2;
        public EventReprositoryi(string databasePath)
        {
            database2 = new SQLiteConnection(databasePath);
            database2.CreateTable<EventTable>();
        }
        public int Count()
        {
            return database2.Table<EventTable>().Count();
        }
        public IEnumerable<EventTable> GetItems()
        {
            return database2.Table<EventTable>().ToList();
        }
        public EventTable GetItem(int id) => database2.Get<EventTable>(id);
        public int DeleteItem(int id)
        {
            return database2.Delete<EventTable>(id);
        }
        public int SaveItem(EventTable item)
        {
            if (item.ID != 0)
            {
                database2.Update(item);
                return item.ID;
            }
            else
            {
                return database2.Insert(item);
            }
        }

        public void DeleteAll()
        {
            database2.Execute("DELETE FROM Events");
        }
    }
}