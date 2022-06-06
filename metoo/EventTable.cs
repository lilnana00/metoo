using SQLite;
using System;

namespace metoo
{
    [Table("Events")]
    public class EventTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string EventName { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }
        public DateTime DT { get; set; }
        public bool IsActive { get; set; }
    }
}