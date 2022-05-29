using SQLite;

namespace metoo
{
    [Table("Comments")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public int EventID { get; set; }
        public string Datetime { get; set; }
        public string Text { get; set; }

    }
}