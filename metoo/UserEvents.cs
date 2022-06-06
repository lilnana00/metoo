using SQLite;


namespace metoo
{
    [Table("UsersToEvents")]
    public class UserEvents
    {
        public int UserID { get; set; }
        public int EventID { get; set; }
    }
}
