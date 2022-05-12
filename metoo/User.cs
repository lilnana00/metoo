using SQLite;


namespace metoo
{
    [Table("Users")]
    public class User 
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }

    }
}
