using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace metoo
{
    public class EventReprository
    {
        SQLiteConnection database2;
        public EventReprository(string databasePath)
        {
            database2 = new SQLiteConnection(databasePath);
            database2.CreateTable<EventTable>();
        }
        public int Count()
        {
            return database2.Table<EventTable>().Count();
        }
        public List<EventTable> GetItems()
        {
            return database2.Table<EventTable>().ToList();
        }
        public EventTable GetItem(int id) 
        { 
            return database2.Get<EventTable>(id); 
        }
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
        public int GetCreatorCount(int ID)
        {
            return database2.Query<EventTable>("select * from Events where CreatorID=?", ID).Count();
        }
    }
}